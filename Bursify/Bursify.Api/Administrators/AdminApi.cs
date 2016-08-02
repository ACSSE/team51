using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;
using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.Uow;

namespace Bursify.Api.Administrators
{
    class AdminApi
    {
        private Repository<Institution> institutionRepository;
        private Repository<Subject> subjectRepository;
        private IUnitOfWorkFactory unitOfWorkFactory;

        public AdminApi(Repository<Institution> institutionRepository, Repository<Subject> subjectRepository,
            IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.institutionRepository = institutionRepository;
            this.subjectRepository = subjectRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
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
                subjectRepository.Save(new Subject
                {
                    Name = name,
                    SubjectLevel = level,
                    Period = period
                });
                uow.Commit();
            }
        }
    }
}
