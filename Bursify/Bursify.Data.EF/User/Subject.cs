using System.Collections.Generic;
using Bursify.Data.EF;
using Bursify.Data.EF.SponsorUser;
using Bursify.Data.EF.StudentUser;

namespace Bursify.Data.User
{
    public class Subject : IEntity 
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }

        public int Id
        {
            get { return SubjectId; }
        }

        public ICollection<StudentSubject> StudentSubjects { get; set; }
        public ICollection<SponsorshipRequirement> Requirements { get; set; } 
    }
}