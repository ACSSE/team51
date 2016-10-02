using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bursify.Data.EF.Entities.Bridge;
using Bursify.Data.EF.Entities.SponsorUser;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;
using Bursify.Data.EF.Uow;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Globalization;
using Microsoft.Ajax.Utilities;

namespace Bursify.Data.EF.Repositories
{
    //some of these methods dont need to be created
    public class StudentSponsorshipRepository : BridgeRepository<StudentSponsorship>
    {
        private readonly DataSession _dataSession;

        public StudentSponsorshipRepository(DataSession dataSession)
            : base(dataSession)
        {
            _dataSession = dataSession;
        }

        //for student
        public void ApplyForSponsorship(int studentId, int sponsorshipId)
        {
            var newApplication = new StudentSponsorship()
            {
                StudentId = studentId,
                SponsorshipId = sponsorshipId,
                ApplicationDate = DateTime.UtcNow,
                Status = "Pending",
                SponsorshipOffered = false
            };

            Save(newApplication);
        }

        //for sponsor
        public bool ConfirmSponsorship(int studentId, int sponsorshipId)
        {
            var application = LoadByIds(studentId, sponsorshipId);

            if (application == null)
            {
                return false;
            }

            application.Status = "Approved";

            Save(application);

            return true;
        }

        //for sponsor
        public void OfferSponsorship(int userId, int sponsorshipId)
        {
            var newApplication = new StudentSponsorship()
            {
                StudentId = userId,
                SponsorshipId = sponsorshipId,
                ApplicationDate = DateTime.UtcNow,
                Status = "Pending",
                SponsorshipOffered = true
            };

            Save(newApplication);
        }

        public List<StudentSponsorship> GetStudentsApplications(int userId)
        {
            return FindMany(application => application.StudentId == userId).ToList();
        }

        public List<StudentSponsorship> GetSponsorApplicants(int sponsorshipId)
        {
            return
                FindMany(applicant => applicant.SponsorshipId == sponsorshipId)
                    .Where(x => x.Status == "Pending")
                    .ToList();
        }

        public Dictionary<int?, int> GetSponsorApplicantsPerWeek(int sponsorshipId)
        {
            var applications = _dataSession.UnitOfWork.Context.Set<StudentSponsorship>()
                .Where(x => x.SponsorshipId == sponsorshipId)
                .GroupBy(x => SqlFunctions.DatePart("week", x.ApplicationDate))
                .ToDictionary(v => v.Key, v => v.Count());

            return applications;
        }

        public Dictionary<string, int> GetMaleFemaleRatio(int sponsorshipId)
        {
            var applicantions = FindMany(x => x.SponsorshipId == sponsorshipId);

            int maleCount = 0, femaleCount = 0;

            foreach (var applicantion in applicantions)
            {
                var student = _dataSession.UnitOfWork.Context
                    .Set<Student>()
                    .FirstOrDefault(x => x.ID == applicantion.StudentId);

                if (student != null && student.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase))
                {
                    maleCount++;
                }
                else
                {
                    femaleCount++;
                }
            }

            var dictionary = new Dictionary<string, int>
            {
                {"Male", maleCount},
                {"Female", femaleCount},
                {"Total", maleCount + femaleCount}
            };

            return dictionary;
        }

        public Dictionary<string, int> GetApplicantsPerprovince(int sponsorshipId)
        {
            var applications = _dataSession.UnitOfWork.Context.Set<StudentSponsorship>()
                .Where(x => x.SponsorshipId == sponsorshipId)
                .DistinctBy(x => x.StudentId)
                .ToList();

            var dictionary = new Dictionary<string, int>
            {
                {"Eastern Cape", 0},
                {"Free State", 0},
                {"Gauteng", 0},
                {"Kwa-Zulu Natal", 0},
                {"Limpopo", 0},
                {"Mpumalanga", 0},
                {"Northern Cape", 0},
                {"North West", 0},
                {"Western Cape", 0}
            };

            foreach (var application in applications)
            {
                var address = _dataSession.UnitOfWork.Context.Set<UserAddress>()
                    .FirstOrDefault(x => x.BursifyUserId == application.StudentId);

                if (address == null || !dictionary.ContainsKey(address.Province)) continue;
                string province = address.Province;
                dictionary[province] += 1;
            }

            return dictionary;
        }

        public double GetApplicantOverallAverage(int sponsorshipId)
        {
            var applications = FindMany(x => x.SponsorshipId == sponsorshipId);

            var studentReports =
                applications.Select(
                    application =>
                        _dataSession.UnitOfWork.Context.Set<StudentReport>()
                            .Where(x => x.StudentId == application.StudentId)
                            .OrderByDescending(x => x.ReportYear)
                            .ThenBy(x => x.ReportPeriod.Equals("Semester 2")
                                ? 1
                                : x.ReportPeriod.Equals("Semester 1")
                                    ? 2
                                    : x.ReportPeriod.Equals("Term 4")
                                        ? 3
                                        : x.ReportPeriod.Equals("Term 3")
                                            ? 4
                                            : x.ReportPeriod.Equals("Term 2")
                                                ? 5
                                                : x.ReportPeriod.Equals("Term 1") ? 6 : 7)
                            .FirstOrDefault()).ToList();

            double total = studentReports.Aggregate<StudentReport, double>(0,
                (current, report) => current + report.Average);


            return total/studentReports.Count;
        }

        public List<Sponsorship> GetStudentsAppliedSponsorships(int userId)
        {
            var sponsorships =
                FindMany(x => x.StudentId == userId)
                    .Where(x => x.Status == "Pending")
                    .Select(s => s.Sponsorship)
                    .ToList();
            return sponsorships;
        }

        public List<Student> GetApplyingStudents(int sponsorshipId)
        {
            var students =
                FindMany(x => x.SponsorshipId == sponsorshipId)
                    .Where(x => x.Status == "Pending").Select(s => s.Student).ToList();

            return students;
        }

        public List<Student> GetStudentsSponsored(int sponsorshipId)
        {
            //var students = (from s in DbContext.Set<StudentSponsorship>() where s.SponsorshipId == sponsorshipId select s.Student).ToList()
            //this query thanx to resharper!
            var students =
                FindMany(x => x.SponsorshipId == sponsorshipId)
                    .Where(x => x.Status != "Pending" && x.Status != "Declined").Select(s => s.Student).ToList();

            return students;
        }

        public StudentSponsorship GetStudentSponsorship(int studentId, int sponsorshipId)
        {
            return
                FindSingle(sponsorship =>
                    sponsorship.leftId == studentId
                    && sponsorship.rightId == sponsorshipId);
        }

        public List<Sponsorship> LoadSponsorshipSuggestions(int studentId)
        {
            //get student
            var student = _dataSession.UnitOfWork.Context
                .Set<Student>()
                .FirstOrDefault(x => x.ID == studentId);

            //get most recent student report
            var report = _dataSession.UnitOfWork.Context.Set<StudentReport>()
                .Where(x => x.StudentId == studentId)
                .OrderByDescending(x => x.ReportYear)
                .ThenBy(x => x.ReportPeriod.Equals("Semester 2")
                    ? 1
                    : x.ReportPeriod.Equals("Semester 1")
                        ? 2
                        : x.ReportPeriod.Equals("Term 4")
                            ? 3
                            : x.ReportPeriod.Equals("Term 3")
                                ? 4
                                : x.ReportPeriod.Equals("Term 2")
                                    ? 5
                                    : x.ReportPeriod.Equals("Term 1") ? 6 : 7)
                .FirstOrDefault();

            //get student address
            var address = _dataSession.UnitOfWork.Context
                .Set<UserAddress>()
                .FirstOrDefault(x => x.BursifyUserId == studentId);

            //get sponsorships based on education level
            var sponsorships = _dataSession.UnitOfWork.Context
                .Set<Sponsorship>()
                .Where(x => student.CurrentOccupation.Equals(x.EducationLevel))
                .Include(x => x.Requirements)
                .ToList();

            var addressList =
                sponsorships.Where(
                    sponsorship =>
                        address != null &&
                        (sponsorship.Province.Contains(address.Province) ||
                         sponsorship.Province.Equals("All", StringComparison.OrdinalIgnoreCase))).ToList();

            //check study field
            var fieldList = CheckStudyFields(sponsorships, student);

            //check average
            var averageList =
                sponsorships.Where(sponsorship => report != null
                                                  && report.Average >= sponsorship.AverageMarkRequired)
                    .ToList();

            var ageList = CheckAge(sponsorships, student);

            /*--------advanced preferences----------*/
            var prefList = CheckAdvancedPreferences(sponsorships, student);

            var finalList = sponsorships.Union(addressList).Union(fieldList).Union(averageList).Union(prefList).Union(ageList).ToList();



            return finalList;
        }

        private List<Sponsorship> CheckStudyFields(List<Sponsorship> sponsorships, Student student)
        {
            var sponsorshipList = new List<Sponsorship>();

            if (student.StudyField.Contains(","))
            {
                var studentFields = student.StudyField.Split(',');

                sponsorshipList.AddRange(from field in studentFields
                    from sponsorship in sponsorships
                    where sponsorship.StudyFields.Contains(field)
                    select sponsorship);
            }
            else
            {
                var studentField = student.StudyField;

                sponsorshipList.AddRange(
                    sponsorships.Where(sponsorship => sponsorship.StudyFields.Contains(studentField)));
            }

            return sponsorshipList;
        }

        private List<Sponsorship> CheckAdvancedPreferences(List<Sponsorship> sponsorships, Student student)
        {
            var institution = _dataSession.UnitOfWork.Context
                .Set<Institution>()
                .FirstOrDefault(x => x.ID == student.InstitutionID);

            //check gender
            var genderList =
                sponsorships.Where(
                    sponsorship =>
                        !sponsorship.GenderPreference.IsNullOrWhiteSpace() &&
                        student.Gender.Equals(sponsorship.GenderPreference) ||
                        sponsorship.GenderPreference.Equals("All", StringComparison.OrdinalIgnoreCase))
                    .ToList();

            //check race
            var raceList =
                sponsorships.Where(
                    sponsorship =>
                        !sponsorship.RacePreference.IsNullOrWhiteSpace() &&
                        (sponsorship.RacePreference.Equals(student.Race) ||
                         sponsorship.RacePreference.Equals("All", StringComparison.OrdinalIgnoreCase))).ToList();

            //check disability
            var disabilityList =
                sponsorships.Where(sponsorship =>
                    sponsorship.DisabilityPreference).ToList();

            //check institution
            var schoolList =
                sponsorships.Where(
                    sponsorship => 
                    !sponsorship.InstitutionPreference.IsNullOrWhiteSpace() &&
                    institution != null
                                   && sponsorship.InstitutionPreference.Contains(institution.Name))
                    .ToList();

            var finalList = genderList.Union(raceList).Union(disabilityList).Union(schoolList).ToList();

            return finalList;
        }

        private List<Sponsorship> CheckAge(List<Sponsorship> sponsorships, Student student)
        {
            var ageList = (from sponsorship in sponsorships
                let age = sponsorship.AgeGroup.Split('-')
                where
                    sponsorship.AgeGroup.Equals("All", StringComparison.OrdinalIgnoreCase) ||
                    (student.Age >= Convert.ToInt32(age[0]) && student.Age <= Convert.ToInt32(age[1]))
                select sponsorship).ToList();

            return ageList;
        }
    }
}