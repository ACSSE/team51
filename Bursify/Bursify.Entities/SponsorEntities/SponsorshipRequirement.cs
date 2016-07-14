using Bursify.Entities.StudentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bursify.Entities.SponsorEntities
{
    public class SponsorshipRequirement
    {
        public int SponsorshipId { get; set; }
        public int SubjectId { get; set; }
        public int RequiredMark { get; set; }

        public virtual Sponsorship Sponsorship { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
