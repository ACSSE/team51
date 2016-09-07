using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Uow;

//this class it not needed but being used anyway can be removed later and functions being used will use bridge repository
namespace Bursify.Data.EF.Repositories
{
    public class StudentRepository : Repository<Student>
    {
        public StudentRepository(DataSession dataSession) : base(dataSession)
        {
            
        }
        /*private BridgeRepository<StudentSubject> studentSubjectBridgeRepository;

        

        public void addSubject(StudentSubject sb) 
        {
            studentSubjectBridgeRepository.Save(sb);
        }

        //this method is a alternative to be tested might not work
        public void addSubjectv2(StudentSubject sb)
        {
            var st = FindSingle(x => x.ID == sb.StudentId);
            Student student = (Student) st;

            student.StudentSubjects.Add(sb);
        }*/


    }
}
