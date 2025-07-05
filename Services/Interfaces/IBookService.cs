using ASPNET_006_Book_Vault.Models;

namespace ASPNET_006_Book_Vault.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByKeyAsync(int id);
    }
}