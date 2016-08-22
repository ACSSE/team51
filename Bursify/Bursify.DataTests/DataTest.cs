using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.Entities.Bridge;
using Bursify.Data.EF.Uow;

namespace Bursify.DataTests
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void test()
        {
            var dataSession = new DataSession();
            var uowFactory = new UnitOfWorkFactory(dataSession);
            var uow = uowFactory.CreateUnitOfWork();
            BridgeRepository<CampaignReport> campaignReportBridgeRepository = new BridgeRepository<CampaignReport>(dataSession);

                campaignReportBridgeRepository.Save(new CampaignReport()
                {
                    BursifyUserId = 3,
                    CampaignId = 1,
                    Reason = "reason"
                });
            uow.Commit();

                //foreach (var cs in c)
                //{
                //    MessageBox.Show(cs.ID + "");
                //}

            }
    }
}
