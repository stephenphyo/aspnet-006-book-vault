using AutoMapper;
using ASPNET_006_Book_Vault.Models;
using ASPNET_006_Book_Vault.Repositories.Interfaces;
using ASPNET_006_Book_Vault.Services.Interfaces;
using ASPNET_006_Book_Vault.DTOs.BookDTO;

namespace ASPNET_006_Book_Vault.Services
{
    public class BookService : IBookService
    {
        /*** Properties ***/
        private readonly IRepository<Book> _repoBook;
        private readonly IMapper _mapper;

        /*** Constructor ***/
        public BookService(IRepository<Book> repoBook, IMapper mapper)
        {
            _repoBook = repoBook;
            _mapper = mapper;
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

        public async Task<Book> AddBookAsync(CreateBookDTO book)
        {
            var newBook = _mapper.Map<Book>(book);
            newBook.CreatedDate = DateTime.Now;
            newBook.ModifiedDate = DateTime.Now;

            await _repoBook.AddAsync(newBook);
            await _repoBook.SaveAsync();

            return newBook;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var existingBook = await _repoBook.GetByKeyAsync<int>(id);
            if (existingBook != null)
            {
                await _repoBook.DeleteAsync(id);
                await _repoBook.SaveAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}