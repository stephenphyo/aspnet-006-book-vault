namespace ASPNET_006_Book_Vault.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByKeyAsync<TKey>(TKey key);
        Task AddAsync(T entity);
        Task DeleteAsync<TKey>(TKey key);
        Task SaveAsync();
    }
}