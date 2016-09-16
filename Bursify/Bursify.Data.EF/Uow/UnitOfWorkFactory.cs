namespace Bursify.Data.EF.Uow
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly DataSession _dataSession;

        public UnitOfWorkFactory(DataSession dataSession)
        {
            _dataSession = dataSession;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            DataContext context = DataContext.Create(@"Server=tcp:bursifyserver.database.windows.net,1433;Initial Catalog=BursifyDB;Persist Security Info=False;User ID=brandon;Password=Bursify123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            IUnitOfWork unitOfWork = new UnitOfWork(context);

            _dataSession.UnitOfWork = unitOfWork;

            return unitOfWork;
        }
    }
}