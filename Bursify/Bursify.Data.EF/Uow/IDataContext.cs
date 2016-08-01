namespace Bursify.Data.EF.Uow
{
    public interface IDataContext
    {
        DataContext Context { get; }
    }
}