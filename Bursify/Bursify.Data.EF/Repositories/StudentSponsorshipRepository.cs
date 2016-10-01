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
                            .ThenBy(x => x.ReportPeriod.Equals("Semester 2") ? 1 : 
                                         x.ReportPeriod.Equals("Semester 1") ? 2 : 
                                         x.ReportPeriod.Equals("Term 4") ? 3 :
                                         x.ReportPeriod.Equals("Term 3") ? 4 :
                                         x.ReportPeriod.Equals("Term 2") ? 5 :
                                         x.ReportPeriod.Equals("Term 1") ? 6 : 7)
                            .FirstOrDefault()).ToList();

            double total = studentReports.Aggregate<StudentReport, double>(0,
                (current, report) => current + report.Average);


            return total / studentReports.Count;
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

            //get student report

            //get student address

            //get sponsorships based on education level

            //check study field

            //check average

            /*--------advanced preferences----------*/

                //check gender

                //check race

                //check disability

                //check institution

            return null;
        }

        private static bool CheckAge(string ageGroup, int studentAge)
        {
            var age = ageGroup.Split('-');

            if (ageGroup.Equals("Any", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return studentAge >= Convert.ToInt32(age[0]) && studentAge <= Convert.ToInt32(age[1]);
        }

        //done in api using generic repo
        //public Student GetApplicant(int userId)
        //{
        //    var student = new StudentRepository(_dataSession);

        //    return student.GetStudent(userId);
        //}
    }
}