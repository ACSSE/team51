using System.Linq;
using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Entities.User;
using Bursify.Data.EF.Uow;

namespace Bursify.Data.EF.Repositories
{
    public class BursifyUserRepository : Repository<BursifyUser>
    {
        public BursifyUserRepository(DataSession dataSession) : base(dataSession)
        {
        }

        public BursifyUser GetUserByEmail(string email)
        {
            var user = FindSingle(x => x.Email.Equals(email));
            return user;
        }


        public BursifyUser GetUserByUsername(string userName)
        {
            var user = FindSingle(x => x.Name == userName);
            return user;
        }
    }
}
