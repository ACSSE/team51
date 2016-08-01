using System.Collections.Generic;
using System.Linq;
using Bursify.Data.EF.StudentUser;
using Bursify.Data.User;

namespace Bursify.Web.Models
{
    public class SubjectViewModel
    {
        #region Variables

        //entry Id
        public int ID { get; set; }

        //subject model plus the ID
        public string Name { get; set; }
        public string SubjectLevel { get; set; }
        
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int MarkAcquired { get; set; }

        #endregion

        #region Subject

        public Subject MapSingleSubject(Subject subject)
        {
            return new Subject()
            {
                ID = subject.ID,
                Name = subject.Name,
                SubjectLevel = subject.SubjectLevel
            };
        }

        public List<Subject> MapMultipleSubjects(List<Subject> subjects)
        {
            return (from subject in subjects select MapSingleSubject(subject)).ToList();
        }

        #endregion

        #region StudentSubject

        public StudentSubject MapSingleStudentSubject(StudentSubject studentSubject)
        {
            return new StudentSubject()
            {
                ID = studentSubject.ID,
                StudentId = studentSubject.StudentId,
                SubjectId = studentSubject.SubjectId,
                MarkAcquired = studentSubject.MarkAcquired
            };
        }

        public List<StudentSubject> MapMultipleStudentSubjects(List<StudentSubject> studentSubjects)
        {
            return (from studentSubject in studentSubjects select MapSingleStudentSubject(studentSubject)).ToList();
        }

        #endregion
    }
}