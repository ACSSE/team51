using Bursify.Data.EF.Uow;
using Bursify.Data.EF.User;

namespace Bursify.Data.EF.Repositories
{
    public class BursifyUserRepository : Repository<BursifyUser>
    {
        private IUnitOfWorkFactory unitOfWorkFactory;
        public BursifyUserRepository(DataSession dataSession, IUnitOfWorkFactory unitOfWorkFactory) : base(dataSession)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
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


        public void UpdateUser(BursifyUser user)
        {
            var oldUser = FindSingle(x => x.ID == user.ID);
            if (oldUser != null)
            {
                oldUser = user;
                Save(oldUser);
            }
        }


    }
}
