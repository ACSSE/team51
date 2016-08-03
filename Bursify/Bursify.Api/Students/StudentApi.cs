using System;
using System.Collections.Generic;
using System.Linq;
using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.Uow;
using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Entities.SponsorUser;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.Bridge;
using Bursify.Data.EF.Entities.User;

namespace Bursify.Api.Students
{
    public class StudentApi
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public StudentApi(IUnitOfWorkFactory unitOfWorkFactory, AccountRepository accountRepository, CampaignRepository campaignRepository, SponsorshipRepository sponsorshipRepository, SponsorRepository sponsorRepository, StudentRepository studentRepository, InstitutionRepository institutionRepository, StudentSponsorshipRepository studentSponsorshipRepository, SubjectRepository subjectRepository, StudentSubjectRepository studentSubjectRepository)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
            _accountRepository = accountRepository;
            _campaignRepository = campaignRepository;
            _sponsorshipRepository = sponsorshipRepository;
            _sponsorRepository = sponsorRepository;
            _studentRepository = studentRepository;
            _institutionRepository = institutionRepository;
            _subjectRepository = subjectRepository;

            _studentSponsorshipRepository = studentSponsorshipRepository;
            _studentSubjectRepository = studentSubjectRepository;
        }

        #region Variables

        // Normal entities
        private readonly AccountRepository _accountRepository;
        private readonly CampaignRepository _campaignRepository;
        private readonly SponsorshipRepository _sponsorshipRepository;
        private readonly SponsorRepository _sponsorRepository;
        private readonly StudentRepository _studentRepository;
        private readonly InstitutionRepository _institutionRepository;
        private readonly SubjectRepository _subjectRepository;

        //bridging entities
        private readonly StudentSponsorshipRepository _studentSponsorshipRepository;
        private readonly StudentSubjectRepository _studentSubjectRepository;

        #endregion

        #region Campaign

        //done
        public void SaveCampaign(Campaign campaign)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                _campaignRepository.Save(campaign);
                uow.Commit();
            }
        }

        /// <summary>
        /// Get a single camapign
        /// </summary>
        /// <param name="campaignId"> Id for the campaign </param>
        /// <returns> A single campaign </returns>
        public Campaign GetSingleCampaign(int campaignId)   //done
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _campaignRepository.GetCampaign(campaignId);
            }
        }

        /// <summary>
        /// Get a single campaign
        /// </summary>
        /// <param name="campaignId"> Id of campaign to retrieve </param>
        /// <param name="userId"> Id of student </param>
        /// <returns></returns>
        public Campaign GetSingleCampaign(int campaignId, int userId)   //done
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _campaignRepository.GetCampaign(campaignId, userId);
            }
        }

        /// <summary>
        /// Gets all active the campaigns
        /// </summary>
        /// <returns> All active campaigns</returns>
        public List<Campaign> GetAllCampaigns() //done
        {
            List<Campaign> campaigns = null;
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                campaigns = _campaignRepository.GetAllCampaigns();
            }

            return campaigns;
        }

        /// <summary>
        /// Gets all campaigns belonging to a specific student
        /// </summary>
        /// <param name="userId"> unique id for the student </param>
        /// <returns> List of campaigns created by a student </returns>
        public List<Campaign> GetAllCampaigns(int userId)   //done
        {
            List<Campaign> userCampaigns = null;
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                userCampaigns = _campaignRepository.GetUserCampaigns(userId).ToList();
            }
            return userCampaigns;
        }

        //for later
        public void ShareCampaign(int id)
        {
            throw new NotImplementedException();
        }

        ////done use one in membership api
        //public Campaign EndorseCampaign(int campaignId)
        //{
        //    using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
        //    {
        //        var campaign = _campaignRepository.EndorseCampaign(campaignId);

        //        _campaignRepository.Save(campaign);

        //        uow.Commit();

        //        return campaign;
        //    }
        //}

        //done
        public List<Campaign> SearchCampaigns(string criteria)  //done
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _campaignRepository.FindCampaigns(criteria.ToUpper()).ToList();
            }
        }

        //done
        public void SaveCampaignAccount(Account account)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                _accountRepository.Save(account);

                uow.Commit();
            }
        }

        //done
        public Account GetCampaignAccount(int campaignId)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _accountRepository.GetAccount(campaignId);
            }
        }

        #endregion

        #region Sponsor

        //done
        public List<Sponsor> GetAllSponsors()
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _sponsorRepository.GetAllSponsors();
            }
        }

        //done
        public List<Sponsor> GetTopTenSponsors()
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _sponsorRepository.GetTop10Sponsors();
            }
        }

        //done
        public Sponsor GetSponsor(int sponsorId)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _sponsorRepository.GetSponsor(sponsorId);
            }
        }

        #endregion

        #region Sponsorship

        //done
        public void SaveSponsorship(Sponsorship sponsorship)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                _sponsorshipRepository.Save(sponsorship);

                uow.Commit();
            }
        }

        //done
        public List<Sponsorship> GetAllSponsorships()
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _sponsorshipRepository.GetAllSponsorships();
            }
        }

        //done
        public List<Sponsorship> GetAllSponsorships(int userId)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _sponsorshipRepository.GetAllSponsorships(userId);
            }
        }

        //done
        public List<Sponsorship> GetAllSponsorships(string type)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _sponsorshipRepository.GetAllSponsorships(type);
            }
        }

        //done
        public Sponsorship GetSponsorship(int id, int userId)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _sponsorshipRepository.GetSponsorship(id, userId);
            }
        }

        //done
        public Sponsorship GetSponsorship(int id)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _sponsorshipRepository.GetSponsorship(id);
            }
        }

        //done
        public List<Sponsorship> SearchSponsorships(string criteria)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _sponsorshipRepository.FindSponsorships(criteria.ToUpper()).ToList();
            }
        }

        //done
        public List<Sponsorship> LoadSponsorshipSuggestions(int studentId)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var student = GetStudent(studentId);

                return _sponsorshipRepository.LoadSponsorshipSuggestions(student);
            }
        }

        //for later
        public void RateSponsorship()
        {
            throw new NotImplementedException();
        }

        //for later
        public void ShareSponsorship()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Student

        public void SaveStudent(Student student)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                _studentRepository.Save(student);

                uow.Commit();
            }
        }

        public List<Student> GetAllStudents()
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _studentRepository.LoadAll();
            }
        }

        public Student GetStudent(int studentId)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _studentRepository.LoadById(studentId);
            }
        }

        public Student GetStudentApplicant(int userId)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _studentRepository.LoadById(userId);
            }
        }

        public void ApplyForSponsorship(StudentSponsorship studentSponsorship)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                _studentSponsorshipRepository.Save(studentSponsorship);

                uow.Commit();
            }
        }

        public bool ConfirmSponsorship(int studentId, int sponsorshipId, string confirmationMessage)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var application = _studentSponsorshipRepository.GetStudentSponsorship(studentId, sponsorshipId);

                if (application == null)
                {
                    return false;
                }

                application.Status = confirmationMessage;

                _studentSponsorshipRepository.Save(application);

                uow.Commit();

                return true;
            }
        }

        #endregion

        #region School

        //done
        public Institution GetInstitution(int userId)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _institutionRepository.GetInstitution(userId);
            }
        }

        //done
        public void SaveInstitution(Institution institution)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                _institutionRepository.Save(institution);
                uow.Commit();
            }
        }

        #endregion

        #region Subject

        public void AddSubjects(List<Subject> subjects)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                _subjectRepository.Save(subjects);

                uow.Commit();
            }
        }

        public void AddSubject(Subject subject)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                _subjectRepository.Save(subject);

                uow.Commit();
            }
        }

        public void AddStudentSubject(StudentSubject studentSubject)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                _studentSubjectRepository.Save(studentSubject);

                uow.Commit();
            }
        }

        public void AddStudentSubjects(List<StudentSubject> studentSubjects)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                _studentSubjectRepository.Save(studentSubjects);

                uow.Commit();
            }
        }

        public Subject GetSubject(int subjectId)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _subjectRepository.GetSubject(subjectId);
            }
        }

        public List<Subject> GetSubjects()
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _subjectRepository.GetSubjects();
            }
        }

        public List<Subject> GetSubjects(string educationLevel)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _subjectRepository.GetSubjects(educationLevel);
            }
        }

        public List<StudentSubject> GetAllSubjects(int studentId)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _studentSubjectRepository.GetStudentSubjects(studentId);
            }
        }

        #endregion
    }
}