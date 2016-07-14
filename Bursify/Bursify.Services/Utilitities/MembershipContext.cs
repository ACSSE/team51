using Bursify.Entities.UserEntities;
using System.Security.Principal;

namespace Bursify.Services.Utilitities
{
    public class MembershipContext
    {
        public IPrincipal Principal { get; set; }
        public BursifyUser User { get; set; }
        public bool IsValid()
        {
            return Principal != null;
        }
    }
}
