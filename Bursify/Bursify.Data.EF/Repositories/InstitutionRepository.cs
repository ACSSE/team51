using Bursify.Data.EF.Uow;
using Bursify.Data.EF.User;

namespace Bursify.Data.EF.Repositories
{
    public class InstitutionRepository : Repository<Institution>
    {
        public InstitutionRepository(DataSession dataSession) : base(dataSession)
        {
        }

        public Institution GetInstitution(int id)
        {
            return FindSingle(institution => institution.StudentId == id);
        }
    }
}