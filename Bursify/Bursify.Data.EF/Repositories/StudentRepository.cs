using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.StudentUser;
using Bursify.Data.EF.Uow;
using Bursify.Data.User;

//this class it not needed but being used anyway can be removed later and functions being used will use bridge repository
namespace Bursify.Data.EF.Repositories
{
    public class StudentRepository : Repository<Student>
    {
        private BridgeRepository<StudentSubject> studentSubjectBridgeRepository;

        public StudentRepository(DataSession dataSession, BridgeRepository<StudentSubject> studentSubjectBridgeRepository) : base(dataSession)
        {
            this.studentSubjectBridgeRepository = studentSubjectBridgeRepository;
        }

        public void addSubject(StudentSubject sb) 
        {
            studentSubjectBridgeRepository.Save(sb);
        }

        //this method is a alternative to be tested
        public void addSubjectv2(StudentSubject sb)
        {
            var st = FindSingle(x => x.Id == sb.StudentId);
            Student student = (Student) st;

            student.StudentSubjects.Add(sb);
        }


    }
}
