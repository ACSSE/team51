using System.Collections.Generic;
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

    public class UserAddressRepository : Repository<UserAddress>
    {
        public UserAddressRepository(DataSession dataSession) : base(dataSession)
        {
        }

        public List<UserAddress> GetAllUserAddress(int userId)
        {
            return FindMany(address => address.BursifyUserId == userId);
        }

        public UserAddress GetUserAddress(int userId, string addressType)
        {
            return FindSingle(address =>
                        address.BursifyUserId == userId
                     && address.AddressType.ToUpper().Equals(addressType.ToUpper()));
        }
    }
}
