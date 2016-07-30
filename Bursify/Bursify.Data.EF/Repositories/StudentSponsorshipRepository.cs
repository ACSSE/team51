using System;
using System.Collections.Generic;
using Bursify.Data.EF.StudentUser;
using Bursify.Data.EF.Uow;
using Bursify.Data.EF.User;

namespace Bursify.Data.EF.Repositories
{
    public class StudentSponsorshipRepository : Repository<StudentSponsorship>
    {
        private readonly DataSession _dataSession;

        public StudentSponsorshipRepository(DataSession dataSession) : base(dataSession)
        {
            _dataSession = dataSession;
        }

        public StudentSponsorship GetStudentSponsorship(int studentId, int sponsorshipId)
        {
            return
                FindSingle(sponsorship => 
                    sponsorship.StudentId == studentId 
                &&  sponsorship.SponsorshipId == sponsorshipId);
        }

        public List<StudentSponsorship> GetApplications(int userId)
        {
            return FindMany(application => application.StudentId == userId);
        }

        public List<StudentSponsorship> GetApplicants(int sponsorshipId)
        {
            return FindMany(applicant => applicant.SponsorshipId == sponsorshipId);
        }

        public Student GetApplicant(int userId)
        {
            var student = new StudentRepository(_dataSession);

            return student.GetStudent(userId);
        }
    }
}