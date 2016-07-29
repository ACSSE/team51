using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.CampaignUser;
using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.Uow;
using Bursify.Data.EF.SponsorUser;
using Bursify.Data.EF.StudentUser;
using Bursify.Data.EF.User;

namespace Bursify.Api.Sponsors
{
    class SponsorApi
    {
        private IUnitOfWorkFactory unitOfWorkFactory;
        private SponsorRepository sponsorRepository;
        private SponsorshipRepository sponsorshipRepository;
        private StudentSponsorshipRepository studentSponsorshipRepository;
        private BridgeRepository<SponsorshipRequirement> requirementBridgeRepository;
        private Repository<Student> studentRepository;
        private CampaignSponsorRepository campaignSponsorRepository;
        private CampaignRepository campaignRepository;

        public SponsorApi(IUnitOfWorkFactory unitOfWorkFactory, SponsorRepository sponsorRepository, SponsorshipRepository sponsorshipRepository, CampaignRepository campaignRepository, CampaignSponsorRepository campaignSponsorRepository , BridgeRepository<SponsorshipRequirement> requirementBridgeRepository, Repository<Student> studentRepository, StudentSponsorshipRepository studentSponsorshipRepository)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.sponsorRepository = sponsorRepository;
            this.sponsorshipRepository = sponsorshipRepository;
            this.requirementBridgeRepository = requirementBridgeRepository;
            this.studentRepository = studentRepository;
            this.studentSponsorshipRepository = studentSponsorshipRepository;
            this.campaignSponsorRepository = campaignSponsorRepository;
            this.campaignRepository = campaignRepository;
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
                    ID = sponsorshipId,
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
                AddSponsorship(sponsorship.ID, sponsorship.SponsorId, sponsorship.Name, sponsorship.Description, sponsorship.ClosingDate, sponsorship.EssayRequired, sponsorship.SponsorshipValue, sponsorship.StudyFields, sponsorship.Province, sponsorship.AverageMarkRequired, sponsorship.EducationLevel, sponsorship.PreferredInstitutions, sponsorship.ExpensesCovered, sponsorship.TermsAndConditions);
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
        public void OfferSponsorship(int studentId, int sponsorshipId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                studentSponsorshipRepository.ApplyForSponsorship(studentId, sponsorshipId);
                uow.Commit();
            }
        }

        public List<Student> GetStudentsSponsored(int sponsorshipId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return studentSponsorshipRepository.GetStudentsEndorsed(sponsorshipId);
            }
        }

        public List<Student> GetStudentsApplying(int sponsorshipId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return studentSponsorshipRepository.GetApplyingStudents(sponsorshipId);
            }
        }

        public bool ApproveSponsorship(int userId, int sponsorshipId, string confirmationMessage)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return studentSponsorshipRepository.ConfirmSponsorship(userId, sponsorshipId, confirmationMessage);
            }
        }

        public void SponsorCampaign(int sponsorId, int CampaignId, double amount)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                campaignSponsorRepository.Save(new CampaignSponsor()
                {
                    SponsorId = sponsorId,
                    CampaignId = CampaignId,
                    AmountContributed = amount,
                    DateOfContribution = DateTime.UtcNow
                });

                uow.Commit();
            }
        }

        public Campaign EndorseCampaign(int id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var campaignEndorsement = campaignRepository.LoadById(id);

                campaignEndorsement.NumberOfUpVotes += 1;

                return campaignEndorsement;

                uow.Commit();
            }
        }

        public List<Campaign> GetCampaigns()
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return campaignRepository.LoadAll();
            }
        }

        public List<Campaign> GetSupportedCampaigns(int sponsorID)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return campaignSponsorRepository.GetSupportedCamapigns(sponsorID);
            }
        }

    }
}
