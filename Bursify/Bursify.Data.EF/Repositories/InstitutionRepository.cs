using System;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Uow;

namespace Bursify.Data.EF.Repositories
{
    public class InstitutionRepository : Repository<Institution>
    {
        public InstitutionRepository(DataSession dataSession) : base(dataSession)
        {
        }

        public Institution GetInstitution(int id)
        {
            return FindSingle(institution => institution.ID == id);
        }

        public Institution GetInstitution(string name)
        {
            return FindSingle(institution => institution.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}