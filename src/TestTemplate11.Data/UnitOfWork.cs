using System.Threading.Tasks;
using TestTemplate11.Common.Interfaces;

namespace TestTemplate11.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestTemplate11DbContext _dbContext;

        public UnitOfWork(TestTemplate11DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveAsync()
        {
            if (_dbContext.ChangeTracker.HasChanges())
            {
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }
    }
}