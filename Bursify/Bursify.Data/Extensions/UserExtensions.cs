using Bursify.Data.Repositories;
using Bursify.Entities;
using Bursify.Entities.UserEntities;
using System.Linq;

namespace Bursify.Data.Extensions
{
    public static class UserExtensions
    {
        public static BursifyUser GetAUserByEmail(this IEntityBaseRepository<BursifyUser> userRepository, string UserEmail)
        {
            return userRepository.GetAll().FirstOrDefault(x => x.Email == UserEmail);
        }
    }
}
