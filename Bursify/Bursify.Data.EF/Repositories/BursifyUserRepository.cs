using Bursify.Data.EF.Uow;
using Bursify.Data.EF.User;

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
