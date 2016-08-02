using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

        public StudentSponsorshipRepository(DataSession dataSession) : base(dataSession)
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
                SponsorshipConfirmed = "No",
                SponsorshipOffered = "No"
            };

            Save(newApplication);
        }

        //for sponsor
        public bool ConfirmSponsorship(int userId, int sponsorshipId, string confirmationMessage)
        {
            var application = LoadByIds(userId, sponsorshipId);

            if (application == null) { return false; }

            application.SponsorshipConfirmed = confirmationMessage;

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
                SponsorshipConfirmed = "No",
                SponsorshipOffered = "Yes"
            };

            Save(newApplication);
        }

        public List<StudentSponsorship> GetStudentsApplications(int userId)
        {
            return FindMany(application => application.leftId == userId).Where(x => x.SponsorshipConfirmed == "No").ToList();
        }

        public List<StudentSponsorship> GetSponsorApplicants(int sponsorshipId)
        {
            return FindMany(applicant => applicant.rightId == sponsorshipId).Where(x => x.SponsorshipConfirmed == "No").ToList();
        }

        public List<Sponsorship> GetStudentsAppliedSponsorships(int userId)
        {
            var sponsorships =
                FindMany(x => x.leftId == userId)
                    .Where(x => x.SponsorshipConfirmed == "No")
                    .Select(s => s.Sponsorship)
                    .ToList();
            return sponsorships;
        }

        public List<Student> GetApplyingStudents(int sponsorshipId)
        {
            var students =
                FindMany(x => x.SponsorshipId == sponsorshipId)
                    .Where(x => x.SponsorshipConfirmed == "No")
                    .Select(s => s.Student)
                    .ToList();
            return students;
        }

        public List<Student> GetStudentsSponsored(int sponsorshipId)
        {
            //var students = (from s in DbContext.Set<StudentSponsorship>() where s.SponsorshipId == sponsorshipId select s.Student).ToList()
            //this query thanx to resharper!
            var students =
                FindMany(x => x.SponsorshipId == sponsorshipId)
                    .Where(x => x.SponsorshipConfirmed != "No")
                    .Select(s => s.Student)
                    .ToList();
            return students;
        }



        //done in api using generic repo
        //public Student GetApplicant(int userId)
        //{
        //    var student = new StudentRepository(_dataSession);

        //    return student.GetStudent(userId);
        //}
    }
}