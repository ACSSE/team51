using Bursify.Data.EF.Entities.User;
using Bursify.Data.EF.Uow;

namespace Bursify.Data.EF.Repositories
{
    public class BursifyUserRepository : Repository<BursifyUser>
    {
        public BursifyUserRepository(DataSession dataSession) : base(dataSession)
        {
        }

        public BursifyUser GetUserById(int id)
        {
            var user = LoadById(id);
            return user;
        }

        public BursifyUser GetUserByEmail(string email)
        {
            var user = FindSingle(x => x.Email.Equals(email));
            return user;
        }

        public int GetNumberOfUsersRegistered()
        {
            return FindMany(x => x.AccountStatus != "InActive").Count;
        }

        public int GetNumberOfUserRegisteredByType(string type)
        {
            return FindMany(x => x.AccountStatus != "InActive" && x.AccountStatus.ToUpper().Equals(type.ToUpper())).Count;
        }

        public int GetNumberOfUsersByStatus(string status)
        {
            return FindMany(x => x.AccountStatus.ToUpper().Equals(status.ToUpper())).Count;
        }

    }
}
