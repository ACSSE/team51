using Bursify.Data.EF.StudentUser;

namespace Bursify.Web.Models
{
    public class StudentSubjectViewModel
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int MarkAcquired { get; set; }

        public StudentSubjectViewModel(StudentSubject studentSubject)
        {
            StudentId = studentSubject.StudentId;
            SubjectId = studentSubject.SubjectId;
            MarkAcquired = studentSubject.MarkAcquired;
        }
    }
}