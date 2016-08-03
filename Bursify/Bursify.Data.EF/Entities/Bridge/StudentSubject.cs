using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;

namespace Bursify.Data.EF.Entities.Bridge
{
    //public class StudentSubject : IEntity
    public class StudentSubject : IBridgeEntity
    {
        //public int ID { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int MarkAcquired { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }

        public int leftId { get { return StudentId; } }
        public int rightId { get { return SubjectId; } }
    }
}
