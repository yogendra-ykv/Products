using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace DataAccess.Model
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApiDbContext _context;

        public UnitOfWork(ApiDbContext context)
        {
            _context = context;
        }


        public void Dispose()
        {
            _context?.Dispose();
        }

        public bool Commit()
        {
            if (_context == null)
            {
                throw new NullReferenceException("Db context is not set for current transaction");
            }

            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                var dbContext = ((IObjectContextAdapter)_context).ObjectContext;
                var refreshableObjects =
                    from entry in
                        dbContext.ObjectStateManager.GetObjectStateEntries(EntityState.Deleted
                                                                           | EntityState.Modified |
                                                                           EntityState.Unchanged)
                    where entry.EntityKey != null
                    select entry.Entity;
                dbContext.Refresh(RefreshMode.StoreWins, refreshableObjects);
                return false;
            }
        }
    }
}