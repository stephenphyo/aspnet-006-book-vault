using Microsoft.AspNetCore.Mvc;
using ASPNET_006_Book_Vault.Services.Interfaces;
using ASPNET_006_Book_Vault.DTOs.BookDTO;

namespace ASPNET_006_Book_Vault.Controllers.v01
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("/api/[controller]")]
    public class BookController : ControllerBase
    {
        /*** Properties ***/
        private readonly IBookService _svcBook;
        private readonly ILogger<BookController> _logger;

        /*** Constructor ***/
        public BookController(IBookService svcBook, ILogger<BookController> logger)
        {
            _svcBook = svcBook;
            _logger = logger;
        }

        /*** Methods ***/
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _svcBook.GetAllBooksAsync();
            var apiVersion = HttpContext.GetRequestedApiVersion();

            return Ok(new
            {
                apiVersion = $"{apiVersion}",
                data = books
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookByKey(int id)
        {
            var book = await _svcBook.GetBookByKeyAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateNewBook([FromBody] CreateBookDTO book)
        {
            var newBook = await _svcBook.AddBookAsync(book);
            return Created(nameof(GetBookByKey), newBook);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteBookByKey(int id)
        {
            var isExisting = await _svcBook.DeleteBookAsync(id);
            if (!isExisting) return NotFound();
            return NoContent();
        }
    }
}