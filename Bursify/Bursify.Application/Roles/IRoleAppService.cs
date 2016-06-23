using System.Threading.Tasks;
using Abp.Application.Services;
using Bursify.Roles.Dto;

namespace Bursify.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
