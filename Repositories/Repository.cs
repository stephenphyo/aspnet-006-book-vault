using Microsoft.EntityFrameworkCore;
using ASPNET_006_Book_Vault.Data;
using ASPNET_006_Book_Vault.Repositories.Interfaces;

namespace ASPNET_006_Book_Vault.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        /*** Properties ***/
        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        /*** Constructor ***/
        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        /*** Methods ***/
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByKeyAsync<TKey>(TKey key)
        {
            return await _dbSet.FindAsync(key);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task DeleteAsync<TKey>(TKey key)
        {
            var entity = await GetByKeyAsync(key);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}