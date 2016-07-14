using Bursify.Entities.SponsorEntities;
using System.Collections.Generic;

namespace Bursify.Entities.StudentEntities
{
    public class Subject : IEntityBase
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }

        public int ID
        {
            get { return SubjectId; }
        }

        public ICollection<StudentSubject> StudentSubjects { get; set; }
        public ICollection<SponsorshipRequirement> Requirements { get; set; }
    }
}
