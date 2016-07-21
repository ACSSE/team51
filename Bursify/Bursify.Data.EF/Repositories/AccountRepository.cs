using Bursify.Data.EF.CampaignUser;
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
            return FindSingle(accId => accId.CampaignId == id);
        }
    }
}