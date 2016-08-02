using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;
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
    }
}