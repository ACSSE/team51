using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var user = FindSingle(x => x.Email.Contains(email));

            return user;
        }


        public BursifyUser GetUserByUsername(string userName)
        {
            var user = FindSingle(x => x.Name == userName);
            return user;
        }


        public void UpdateUser(BursifyUser user)
        {
            var oldUser = FindSingle(x => x.BursifyUserId == user.BursifyUserId);
            if (oldUser != null)
            {
                oldUser = user;
                Save(oldUser);
            }
        }


    }
}
