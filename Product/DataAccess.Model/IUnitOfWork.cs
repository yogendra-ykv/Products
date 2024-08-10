namespace DataAccess.Model
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}