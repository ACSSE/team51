using System.Collections.Generic;
namespace Bursify.Data.EF.Entities.StudentUser
{
    public class Institution : IEntity
    {
        public Institution()
        {
            Students = new List<Student>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Website { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
