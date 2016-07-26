using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.Uow;
using Bursify.Data.EF.SponsorUser;
using Bursify.Data.EF.StudentUser;

namespace Bursify.Api.Sponsors
{
    class SponsorApi
    {
        private IUnitOfWorkFactory unitOfWorkFactory;
        private SponsorRepository sponsorRepository;
        private SponsorshipRepository sponsorshipRepository;
        private BridgeRepository<SponsorshipRequirement> requirementBridgeRepository;
        private Repository<Student> studentRepository;

        public SponsorApi(IUnitOfWorkFactory unitOfWorkFactory, SponsorRepository sponsorRepository, SponsorshipRepository sponsorshipRepository, BridgeRepository<SponsorshipRequirement> requirementBridgeRepository, Repository<Student> studentRepository)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.sponsorRepository = sponsorRepository;
            this.sponsorshipRepository = sponsorshipRepository;
            this.requirementBridgeRepository = requirementBridgeRepository;
            this.studentRepository = studentRepository;
        }


        public void AddSponsorship(int sponsorshipId, int sponsorId, string name, string description,
            DateTime closingDate, bool essayRequired, double sponsorshipValue, string studyFields, string province,
            int averageMarkRequired, string educationLevel, string preferredInstitutions, string expensesCovered,
            string termsAndConditions)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                sponsorshipRepository.Save(new Sponsorship()
                {
                    SponsorshipId = sponsorshipId,
                    SponsorId = sponsorId,
                    Name = name,
                    Description = description,
                    ClosingDate = closingDate,
                    EssayRequired = essayRequired,
                    SponsorshipValue = sponsorshipValue,
                    StudyFields = studyFields,
                    Province = province,
                    AverageMarkRequired = averageMarkRequired,
                    EducationLevel = educationLevel,
                    PreferredInstitutions = preferredInstitutions,
                    ExpensesCovered = expensesCovered,
                    TermsAndConditions = termsAndConditions,
                });

                uow.Commit();
            }
        }

        public void AddSponsorship(Sponsorship sponsorship)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                AddSponsorship(sponsorship.SponsorshipId, sponsorship.SponsorId, sponsorship.Name, sponsorship.Description, sponsorship.ClosingDate, sponsorship.EssayRequired, sponsorship.SponsorshipValue, sponsorship.StudyFields, sponsorship.Province, sponsorship.AverageMarkRequired, sponsorship.EducationLevel, sponsorship.PreferredInstitutions, sponsorship.ExpensesCovered, sponsorship.TermsAndConditions);
            }
        }

        public void AddSponsorship(int sponsorshipId, int sponsorId, string name, string description,
            DateTime closingDate, bool essayRequired, double sponsorshipValue, string studyFields, string province,
            int averageMarkRequired, string educationLevel, string preferredInstitutions, string expensesCovered,
            string termsAndConditions, List<SponsorshipRequirement> requirements)
        {
            AddSponsorship(sponsorshipId, sponsorId, name, description,
            closingDate, essayRequired, sponsorshipValue, studyFields, province,
            averageMarkRequired, educationLevel, preferredInstitutions, expensesCovered,
            termsAndConditions);
            AddRequirements(requirements);
        }

        public void AddRequirement(SponsorshipRequirement requirement)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                requirementBridgeRepository.Save(requirement);
                uow.Commit();
            }
        }

        public void AddRequirement(int sponsorId, int subjectId, int requiredMark)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                AddRequirement(new SponsorshipRequirement()
                {
                    SubjectId = subjectId,
                    SponsorshipId = sponsorId,
                    RequiredMark = requiredMark
                });
            }
        }

        public void AddRequirements(List<SponsorshipRequirement> requirements)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                foreach (var r in requirements)
                {
                    AddRequirement(r);
                }
            }
        }

        public Student GetStudent(int Id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return studentRepository.LoadById(Id);
            }
        }

        //not sure how to do
        public void ContactStudent()
        {
            
        }

        public List<Student> GetStudentsSponsored(int sponsorshipId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return sponsorshipRepository.GetStudents(sponsorshipId);
            }
        }



    }
}
