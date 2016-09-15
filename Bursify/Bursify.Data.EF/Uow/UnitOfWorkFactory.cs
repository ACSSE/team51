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
            DataContext context = DataContext.Create(@"Data Source=.\SQLEXPRESS;Initial Catalog=BursifyDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            IUnitOfWork unitOfWork = new UnitOfWork(context);

            _dataSession.UnitOfWork = unitOfWork;

            return unitOfWork;
        }
    }
}