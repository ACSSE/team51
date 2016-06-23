using Abp.Authorization;
using Bursify.Authorization.Roles;
using Bursify.MultiTenancy;
using Bursify.Users;

namespace Bursify.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
