using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.Entities.SponsorUser;
using Bursify.Data.EF.Uow;

namespace Bursify.Data.EF.Repositories
{
    public class RequirementRepository : Repository<Requirement>
    {
        public RequirementRepository(DataSession dataSession) : base(dataSession)
        {
        }

    }
}
