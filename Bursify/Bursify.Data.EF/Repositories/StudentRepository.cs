using Bursify.Data.EF.StudentUser;
using Bursify.Data.EF.Uow;

namespace Bursify.Data.EF.Repositories
{
    public class StudentRepository : Repository<Student>
    {
        public StudentRepository(DataSession dataSession) : base(dataSession)
        {
        }
    }
}