




namespace Bursify.Api.AdminApi
{
    public class AdminApi
    {
        private Repository<Institution> institutionRepository;
        private Repository<Subject> subjectRepository;
        private IUnitOfWorkFactory unitOfWorkFactory;

        public AdminApi()
        {
        }

        public void AddHighSchool(string name, string website)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                institutionRepository.Save(new Institution {
                    Name = name,
                    Website = website;
                    Type = "HighSchool"
                });
                uow.Commit();
            }
        }

        public void AddUniversity(string name, string website)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                institutionRepository.Save(new Institution {
                    Name = name,
                    Website = website;
                    Type = "University"
                });
                uow.Commit();
            }
        }


        public void AddCollege(string name, string website)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                institutionRepository.Save(new Institution {
                    Name = name,
                    Website = website;
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

        public void AddSubject(string name, string level)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                subjectRepository.Save(new Subject {
                    Name = name,
                    Level = level;
                });
                uow.Commit();
            }
        }
    }
}