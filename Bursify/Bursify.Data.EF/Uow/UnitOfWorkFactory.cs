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
            DataContext context = DataContext.Create(@"Data Source=.\SQLEXPRESS;Initial Catalog=BursifyDB;Integrated Security=SSPI;");
            IUnitOfWork unitOfWork = new UnitOfWork(context);

            _dataSession.UnitOfWork = unitOfWork;

            return unitOfWork;
        }
    }
}