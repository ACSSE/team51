using Bursify.Entities.StudentEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bursify.Entities.UserEntities
{
    public class Institution : IEntityBase
    {
        [Key, ForeignKey("Student")]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Website { get; set; }

       
        public int ID
        {
            get { return StudentId; }
        }

        public virtual Student Student { get; set; }
    }
}
