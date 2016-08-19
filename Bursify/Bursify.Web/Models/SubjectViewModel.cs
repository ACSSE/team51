using System.Collections.Generic;
using System.Linq;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;
using Bursify.Data.EF.Entities.Bridge;

namespace Bursify.Web.Models
{
    public class SubjectViewModel
    {

        //entry Id
        public int ID { get; set; }
        public string Name { get; set; }
        public string SubjectLevel { get; set; }
        public string Period { get; set; }

        public SubjectViewModel()
        {
            
        }

        public static Subject MapFromStudentSubject(StudentSubjectViewModel studentSubject)
        {
            return new Subject()
            {
                ID = studentSubject.SubjectId,
                Name = studentSubject.SubjectName,
                Period = studentSubject.Period
            };
        }

        public SubjectViewModel(Subject s)
        {
            MapSingleSubject(s);
        }

        public SubjectViewModel MapSingleSubject(Subject subject)
        {
            ID = subject.ID;
            Name = subject.Name;
            Period = subject.Period;
            SubjectLevel = subject.SubjectLevel;
            return this;
        }

        public Subject ReverseMap()
        {
            return new Subject()
            {
                ID = this.ID,
                Name = this.Name,
                Period = this.Period,
                SubjectLevel = this.SubjectLevel
            };
        }

        public static List<SubjectViewModel> MapMultipleSubjects(List<Subject> Subjects)
        {
            List<SubjectViewModel> SubjectVMs = new List<SubjectViewModel>();

            foreach (var i in Subjects)
            {
                SubjectViewModel sVm = new SubjectViewModel(i);
                SubjectVMs.Add(sVm);
            }
            return SubjectVMs;
        }

    }
}