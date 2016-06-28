using Bursify.Data.EF.Uow;
using Bursify.Data.User;
using NUnit.Framework;

namespace Bursify.Tests
{
    [TestFixture]
    public class BursifyUserDataFixture
    {
        [Test]
        public void CanAccessDb()
        {
            DataSession dataSession = new DataSession();
            var uowFactory = new UnitOfWorkFactory(dataSession);
            IUnitOfWork uow = uowFactory.CreateUnitOfWork();

            var user = new BursifyUser();
            user.Name = "Test";
            uow.Context.Set<BursifyUser>().Add(user);

            uow.Context.SaveChanges();
            uow.Commit();
        }
    }
}