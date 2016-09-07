using System;
using System.Collections.Generic;
using System.Linq;
using Bursify.Data.EF.Entities.Bridge;
using Bursify.Data.EF.Entities.SponsorUser;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;
using Bursify.Data.EF.Uow;

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
        public void ApplyForSponsorship(int userId, int sponsorshipId)
        {
            var newApplication = new StudentSponsorship()
            {
                StudentId = userId,
                SponsorshipId = sponsorshipId,
                ApplicationDate = DateTime.UtcNow,
                Status = "Pending",
                SponsorshipOffered = false
            };

            Save(newApplication);
        }

        //for sponsor
        public bool ConfirmSponsorship(int userId, int sponsorshipId, string statusMessage)
        {
            var application = LoadByIds(userId, sponsorshipId);

            if (application == null)
            {
                return false;
            }

            application.Status = statusMessage;

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
            return FindMany(application => application.StudentId == userId).Where(x => x.Status == "Pending").ToList();
        }

        public List<StudentSponsorship> GetSponsorApplicants(int sponsorshipId)
        {
            return
                FindMany(applicant => applicant.SponsorshipId == sponsorshipId)
                    .Where(x => x.Status == "Pending")
                    .ToList();
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
            var student = _dataSession.UnitOfWork.Context.Set<Student>()
                .FirstOrDefault(x => x.ID == studentId);

            if (student != null && student.CurrentOccupation.Equals("Unemployed", StringComparison.OrdinalIgnoreCase)) return null;

            var sponsorships = _dataSession.UnitOfWork.Context.Set<Sponsorship>()
                .Where(x => x.EducationLevel.Equals(student.CurrentOccupation, StringComparison.OrdinalIgnoreCase))
                .ToList();

            var latestReport = DbContext/*_dataSession.UnitOfWork.Context*/.Set<StudentReport>()
                .Where(x => x.StudentId == student.ID)
                .OrderByDescending(x => x.ReportYear)
                .ThenByDescending(x => x.ReportPeriod)
                .FirstOrDefault();

            var school = _dataSession.UnitOfWork.Context
                .Set<Institution>()
                .FirstOrDefault(x => x.ID == student.InstitutionID);

            var address = _dataSession.UnitOfWork.Context
                .Set<UserAddress>()
                .FirstOrDefault(userAddress => userAddress.BursifyUserId == student.ID && userAddress.PreferredAddress.Contains("Residential"));
            //FindMany(x => x.EducationLevel.Equals(student.CurrentOccupation, StringComparison.OrdinalIgnoreCase));

            var suggestionList = sponsorships.Where(sponsorship => 
                                 student != null && school != null && latestReport != null
                                 && sponsorship.StudyFields.Contains(student.StudyField)
                                 && sponsorship.AverageMarkRequired <= latestReport.Average
                                 && CheckAge(sponsorship.AgeGroup, student.Age)
                                 ).ToList();

            //check disability preference

            return suggestionList;
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