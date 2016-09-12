using System;
using System.Collections.Generic;
using System.Linq;
using Bursify.Api.Users;
using Bursify.Data.EF.Entities.Bridge;
using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Entities.SponsorUser;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;
using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.Uow;

namespace Bursify.Api.Sponsors
{
    public class SponsorApi : UserApi
    {
        private SponsorshipRepository sponsorshipRepository;
        private StudentSponsorshipRepository studentSponsorshipRepository;
        private Repository<Student> studentRepository;
        private BridgeRepository<CampaignReport> campaignReportBridgeRepository;
        private SponsorRepository sponsorRepository;

        public SponsorApi(IUnitOfWorkFactory unitOfWorkFactory, BursifyUserRepository userRepository, Repository<UserAddress> userAddressRepository, CampaignRepository campaignRepository, CampaignSponsorRepository campaignSponsorRepository, SponsorshipRepository sponsorshipRepository, StudentSponsorshipRepository studentSponsorshipRepository, Repository<Student> studentRepository, BridgeRepository<CampaignReport> campaignReportBridgeRepository, SponsorRepository sponsorRepository) : base(unitOfWorkFactory, userRepository, userAddressRepository, campaignRepository, campaignSponsorRepository)
        {
            this.sponsorshipRepository = sponsorshipRepository;
            this.studentSponsorshipRepository = studentSponsorshipRepository;
            this.studentRepository = studentRepository;
            this.campaignReportBridgeRepository = campaignReportBridgeRepository;
            this.sponsorRepository = sponsorRepository;
        }

        public void AddSponsor(Sponsor s)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                sponsorRepository.Save(s);
                uow.Commit();
            }
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
                    InstitutionPreference = preferredInstitutions,
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
                AddSponsorship(sponsorship.ID, sponsorship.SponsorId, sponsorship.Name, sponsorship.Description, sponsorship.ClosingDate, sponsorship.EssayRequired, sponsorship.SponsorshipValue, sponsorship.StudyFields, sponsorship.Province, sponsorship.AverageMarkRequired, sponsorship.EducationLevel, sponsorship.InstitutionPreference, sponsorship.ExpensesCovered, sponsorship.TermsAndConditions);
                uow.Commit();
            }
        }

        /*public void AddSponsorship(int sponsorshipId, int sponsorId, string name, string description,
            DateTime closingDate, bool essayRequired, double sponsorshipValue, string studyFields, string province,
            int averageMarkRequired, string educationLevel, string preferredInstitutions, string expensesCovered,
            string termsAndConditions, List<Subject> requirements)
        {
            AddSponsorship(sponsorshipId, sponsorId, name, description,
            closingDate, essayRequired, sponsorshipValue, studyFields, province,
            averageMarkRequired, educationLevel, preferredInstitutions, expensesCovered,
            termsAndConditions);
           // AddRequirements(requirements);
        }*/

        /*public void AddRequirement(Subject requirement)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                requirementBridgeRepository.Save(requirement);
                uow.Commit();
            }
        }*/

        /*public void AddRequirement(int sponsorId, int subjectId, int requiredMark)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                AddRequirement(new SponsorshipRequirement()
                {
                    SubjectId = subjectId,
                    SponsorshipId = sponsorId,
                    RequiredMark = requiredMark
                });

                uow.Commit();
            }
        }*/

        /*public void AddRequirements(List<SponsorshipRequirement> requirements)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                foreach (var r in requirements)
                {
                    AddRequirement(r);
                }

                uow.Commit();
            }
        }*/

        public Sponsor GetSponsor(int sponsorId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return sponsorRepository.GetSponsor(sponsorId);
            }
        }

        //not sure how to do
        public void OfferSponsorship(int studentId, int sponsorshipId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                studentSponsorshipRepository.OfferSponsorship(studentId, sponsorshipId);
                uow.Commit();
            }
        }

        public List<Student> GetStudentsSponsored(int sponsorshipId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return studentSponsorshipRepository.GetStudentsSponsored(sponsorshipId);
            }
        }

        public List<Student> GetStudentsApplying(int sponsorshipId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return studentSponsorshipRepository.GetApplyingStudents(sponsorshipId);
            }
        }

        public bool ApproveSponsorship(int studentId, int sponsorshipId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                bool status = studentSponsorshipRepository.ConfirmSponsorship(studentId, sponsorshipId);
                uow.Commit();
                return status;
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

        public void ReportCampaign(int userId, int campaignId, string reason)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                campaignReportBridgeRepository.Save(new CampaignReport()
                {
                    BursifyUserId = userId,
                    CampaignId = campaignId,
                    Reason = reason
                });

                uow.Commit();
            }
        }

        public List<Sponsorship> GetSponsorSponsorships(int SponsorId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return sponsorRepository.LoadById(SponsorId).Sponsorhips.ToList();
            }
        }
    }
}
