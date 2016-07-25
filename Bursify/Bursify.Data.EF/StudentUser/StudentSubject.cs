using Bursify.Data.User;

namespace Bursify.Data.EF.StudentUser
{
    public class StudentSubject : IEntity
    {
        public int ID { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int MarkAcquired { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
