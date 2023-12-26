using Core.Interfaces;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JobbyContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(JobbyContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var entityType = typeof(TEntity);

            if (!_repositories.ContainsKey(entityType))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(entityType), _context);

                _repositories.Add(entityType, repositoryInstance);
            }

            return (IGenericRepository<TEntity>)_repositories[entityType];
        }
    }
}
