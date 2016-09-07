using System.Collections.Generic;
using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;
using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.Uow;

namespace Bursify.Api.Administrators
{
    public class AdminApi
    {
        private Repository<Institution> institutionRepository;
        private Repository<Subject> subjectRepository;
        private IUnitOfWorkFactory unitOfWorkFactory;
        private BursifyUserRepository userRepository;
        private CampaignRepository campaignRepository;
        private CampaignReportRepository campaignReportBridgeRepository;

        public AdminApi(Repository<Institution> institutionRepository, Repository<Subject> subjectRepository, IUnitOfWorkFactory unitOfWorkFactory, BursifyUserRepository userRepository, CampaignRepository campaignRepository, CampaignReportRepository campaignReportBridgeRepository)
        {
            this.institutionRepository = institutionRepository;
            this.subjectRepository = subjectRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.userRepository = userRepository;
            this.campaignRepository = campaignRepository;
            this.campaignReportBridgeRepository = campaignReportBridgeRepository;
        }

        public void AddHighSchool(string name, string website)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                institutionRepository.Save(new Institution
                {
                    Name = name,
                    Website = website,
                    Type = "HighSchool"
                });
                uow.Commit();
            }
        }

        public void AddUniversity(string name, string website)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                institutionRepository.Save(new Institution
                {
                    Name = name,
                    Website = website,
                    Type = "University"
                });
                uow.Commit();
            }
        }


        public void AddCollege(string name, string website)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                institutionRepository.Save(new Institution
                {
                    Name = name,
                    Website = website,
                    Type = "College"
                });
                uow.Commit();
            }
        }


        public void AddInstitution(Institution institution)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                institutionRepository.Save(institution);
                uow.Commit();
            }
        }

        public void AddSubject(string name, string level, string period)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
               /* subjectRepository.Save(new Subject
                {
                    Name = name,
                    SubjectLevel = level
                });*/
                uow.Commit();
            }
        }

        public void AddSubject(Subject s)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                subjectRepository.Save(s);
                uow.Commit();
            }
        }


        public void VerifyUser(int userId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var user = userRepository.LoadById(userId);
                user.AccountStatus = "Verified";
                uow.Commit();
            }
        }

        public void DeactivateUser(int userId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var user = userRepository.LoadById(userId);
                user.AccountStatus = "Inactive";
                uow.Commit();
            }
        }

        public void BanCampaign(int CampaignId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var campaign = campaignRepository.LoadById(CampaignId);
                campaign.Status = "Banned";
                uow.Commit();
            }
        }


        public int GetNumberActiveCampaigns()
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return campaignRepository.GetCampaignNumbersByStatus("Active");
            }
        }

        public int GetNumberCompletedCampaigns()
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return campaignRepository.GetCampaignNumbersByStatus("Completed");
            }
        }

        public int GetNumberCancelledCampaigns()
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return campaignRepository.GetCampaignNumbersByStatus("Cancelled");
            }
        }

        public int GetNumberOfRegisteredUsers()
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return userRepository.GetNumberOfUsersRegistered();
            }
        }

        public int GetNumberOfInactiveUsers()
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return userRepository.GetNumberOfUsersByStatus("InAcive");
            }
        }

        public int GetRegisteredStudents()
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return userRepository.GetNumberOfUserRegisteredByType("Student");
            }
        }

        public int GetRegisteredSponsors()
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return userRepository.GetNumberOfUserRegisteredByType("Sponsor");
            }
        }

        public List<Campaign> GetReportedCampaigns()
        {
            return campaignReportBridgeRepository.GetReportedCampaigns();
        }


        public void RemoveCampaign(int Id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                campaignRepository.Delete(Id);
                var campaignReports = campaignReportBridgeRepository.GetReportedByCampaignId(Id);
                foreach (var r in campaignReports)
                {
                    campaignReportBridgeRepository.Delete(r);
                }
                uow.Commit();
            }
        }

    }
}
