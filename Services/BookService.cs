using ASPNET_006_Book_Vault.Models;
using ASPNET_006_Book_Vault.Repositories.Interfaces;
using ASPNET_006_Book_Vault.Services.Interfaces;

namespace ASPNET_006_Book_Vault.Services
{
    public class BookService : IBookService
    {
        /*** Properties ***/
        private readonly IRepository<Book> _repoBook;

        /*** Constructor ***/
        public BookService(IRepository<Book> repoBook)
        {
            _repoBook = repoBook;
        }

        /*** Methods ***/
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _repoBook.GetAllAsync();
        }
        public async Task<Book> GetBookByKeyAsync(int id)
        {
            return await _repoBook.GetByKeyAsync<int>(id);
        }
    }
}