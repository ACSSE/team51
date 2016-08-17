using System.Collections.Generic;
using Bursify.Data.EF.Entities.Bridge;
using Bursify.Data.EF.Entities.SponsorUser;
using Bursify.Data.EF.Entities.StudentUser;

namespace Bursify.Data.EF.Entities.User
{
    public class Subject : IEntity 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SubjectLevel { get; set; }
        public string Period { get; set; }

        public ICollection<StudentSubject> StudentSubjects { get; set; }
        public ICollection<SponsorshipRequirement> Requirements { get; set; } 
    }
}