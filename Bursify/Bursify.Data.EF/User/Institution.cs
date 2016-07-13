using Bursify.Data.EF.StudentUser;
using Bursify.Data.StudentUser;

namespace Bursify.Data.EF.User
{
    public class Institution : IEntity
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Website { get; set; }
        
        public int Id
        {
            get{ return StudentId; }
        }

        public virtual Student Student { get; set; }
    }
}
