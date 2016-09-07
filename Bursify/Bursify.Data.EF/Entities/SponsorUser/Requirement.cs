using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bursify.Data.EF.Entities.SponsorUser
{
    public class Requirement : IEntity
    {
        public int ID { get; set; }
        public int SponsorshipId { get; set; }
        public string Name { get; set; }
        public int MarkRequired { get; set; }

        public virtual Sponsorship Sponsorship { get; set; }
    }
}
