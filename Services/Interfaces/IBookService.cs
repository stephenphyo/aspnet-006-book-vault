using ASPNET_006_Book_Vault.Models;
using ASPNET_006_Book_Vault.DTOs.BookDTO;

namespace ASPNET_006_Book_Vault.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByKeyAsync(int id);
        Task<Book> AddBookAsync(CreateBookDTO book);
        Task<bool> DeleteBookAsync(int id);
    }
}