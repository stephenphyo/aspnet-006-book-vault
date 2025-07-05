using Microsoft.AspNetCore.Mvc;
using ASPNET_006_Book_Vault.Services.Interfaces;

namespace ASPNET_006_Book_Vault.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BookController : ControllerBase
    {
        /*** Properties ***/
        private readonly IBookService _svcBook;

        /*** Constructor ***/
        public BookController(IBookService svcBook)
        {
            _svcBook = svcBook;
        }

        /*** Methods ***/
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _svcBook.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookByKey(int id)
        {
            var book = await _svcBook.GetBookByKeyAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }
    }
}