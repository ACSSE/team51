using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.Entities.Bridge;
using Bursify.Data.EF.Uow;
using Bursify.Api.Security;
using System.Windows.Forms;

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


        [TestMethod]
        public void TestCrpty()
        {
            var emailhash = CryptoService.EncryptStringAES("w@w.com", "Bursify");
            MessageBox.Show("Hashed: " + emailhash);

            var email = CryptoService.DecryptStringAES(emailhash, "Bursify");

            MessageBox.Show("email: " + email);
        }
    }
}
