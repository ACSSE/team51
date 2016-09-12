using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Entities.SponsorUser;
using Bursify.Data.EF.Entities.User;
using Bursify.Data.EF.Uow;

namespace Bursify.Data.EF.Repositories
{
    public class AccountRepository : Repository<Account>
    {
        public AccountRepository(DataSession dataSession) : base(dataSession)
        {
        }

        public Account GetAccount(int id)
        {
            return FindSingle(account => account.ID == id);
        }
    }
}