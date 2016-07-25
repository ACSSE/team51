using System;
using Bursify.Data.EF.StudentUser;
using Bursify.Data.EF.Uow;
using Bursify.Data.EF.User;

namespace Bursify.Data.EF.Repositories
{
    public class StudentRepository : Repository<Student>
    {

        public StudentRepository(DataSession dataSession) : base(dataSession)
        {
        }

        public Student GetStudent(int userId)
        {
            return FindSingle(student => student.ID == userId);
        }
    }
}
