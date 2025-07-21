using Microsoft.AspNetCore.Mvc;
using ASPNET_006_Book_Vault.Services.Interfaces;
using ASPNET_006_Book_Vault.DTOs.BookDTO;

namespace ASPNET_006_Book_Vault.Controllers.v02
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("/api/v{version:apiVersion}/[controller]")]
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