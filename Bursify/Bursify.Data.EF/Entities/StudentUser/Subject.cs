using Bursify.Data.EF.Entities.User;

namespace Bursify.Data.EF.Entities.StudentUser
{
    public class Subject : IEntity
    {
        public int ID { get; set; }
        public int StudentReportId { get; set; }
        public string Name { get; set; }
        public int MarkAcquired { get; set; }

        public virtual StudentReport Report { get; set; }
    }
}