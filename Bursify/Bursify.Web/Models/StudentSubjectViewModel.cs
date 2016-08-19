
using System.Collections.Generic;
using Bursify.Data.EF.Entities.Bridge;

namespace Bursify.Web.Models
{
    public class StudentSubjectViewModel
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Period { get; set; }
        public int SubjectMark { get; set; }

        public StudentSubjectViewModel()
        {
        }

        public StudentSubjectViewModel(StudentSubject studentSubject)
        {
            MapSingleSubject(studentSubject);
        }

        public StudentSubjectViewModel MapSingleSubject(StudentSubject studentSubject)
        {
            StudentId = studentSubject.StudentId;
            SubjectId = studentSubject.SubjectId;
            SubjectMark = studentSubject.MarkAcquired;
            return this;
        }

        public StudentSubject ReverseMap()
        {
            return new StudentSubject()
            {
                StudentId = this.StudentId,
                SubjectId = this.SubjectId,
                MarkAcquired = this.SubjectMark,
            };
        }

        public static StudentSubject ReverseMap(StudentSubjectViewModel subject)
        {
            return new StudentSubject()
            {
                StudentId = subject.StudentId,
                SubjectId = subject.SubjectId,
                MarkAcquired = subject.SubjectMark,
            };
        }

        public static List<StudentSubject> ReverseMapMultipleSubjects(List<StudentSubjectViewModel> subjects)
        {
            List<StudentSubject> mappedList = new List<StudentSubject>();

            foreach (var i in subjects)
            {
                mappedList.Add(ReverseMap(i));
            }

            return null;
        }

        public static List<StudentSubjectViewModel> MapMultipleSubjects(List<StudentSubject> studentSubjects)
        {
            List<StudentSubjectViewModel> studentSubjectVm = new List<StudentSubjectViewModel>();

            foreach (var i in studentSubjects)
            {
                StudentSubjectViewModel sVm = new StudentSubjectViewModel(i);
                studentSubjectVm.Add(sVm);
            }
            return studentSubjectVm;
        }
    }
}