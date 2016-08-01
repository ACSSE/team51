using Bursify.Data.EF.StudentUser;

namespace Bursify.Data.EF.User
{
    public class Institution : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Website { get; set; }

        public virtual Student Student { get; set; }
    }
}
