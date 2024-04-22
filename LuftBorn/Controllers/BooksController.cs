using LuftBorn.Application.Dtos.Books;
using LuftBorn.Application.Usecases.Books;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LuftBorn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }


        /// <summary>
        /// Getting All Books
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAllBooks(); 
            return Ok(books);
        }

        /// <summary>
        /// Getting Book By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetBookById/{id:Guid}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var books = await _bookService.GetBookById(id);
            return Ok(books);
        }

        /// <summary>
        /// Create New Book
        /// </summary>
        /// <param name="bookDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateNewBook([FromBody] BookDto bookDto)
        {
            var books = await _bookService.InsertNewBook(bookDto);
            return Ok(books);
        }

        /// <summary>
        /// Update  Book Data
        /// </summary>
        /// <param name="bookDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateBookData([FromBody] BookDto bookDto)
        {
            var books = await _bookService.UpdateBook(bookDto);
            return Ok(books);
        }

        /// <summary>
        /// Remove Book By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteBookById(Guid id)
        {
            var books = await _bookService.DeleteBook(id);
            return Ok(books);
        }
    }
}
