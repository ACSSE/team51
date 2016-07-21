using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.StudentUser;
using Bursify.Data.EF.Uow;
using Bursify.Data.User;

namespace Bursify.Data.EF.Repositories
{
    public class StudentRepository : Repository<Student>
    {

        public StudentRepository(DataSession dataSession) : base(dataSession)
        {
        }

        public void addSubject(int bUserID, Subject subject, int mark)
        {
            var student = FindSingle(x => x.BursifyUserId == bUserID);
            student.StudentSubjects.Add(new StudentSubject
            {
                MarkAcquired = mark,
                StudentId = student.Id,
                
            });
        }
    }
}
