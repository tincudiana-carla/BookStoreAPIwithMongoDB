using BookStore.Data.MongoDB;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PipelineController : Controller
    {
        private readonly IMediator mediator;
        private readonly BookService _bookService;
        public PipelineController(IMediator mediator, BookService bookService)
        {
            this.mediator = mediator;
            _bookService = bookService;
        }

        [HttpGet("count/serbian-authors")]
        public async Task<IActionResult> GetNumberOfBooksBySerbianAuthors()
        {
            var count = await _bookService.GetNumberOfBooksBySerbianAuthorsAsync();
            return Ok(new { Count = count });
        }

        [HttpGet("first-book-of-2022")]
        public async Task<IActionResult> GetFirstBookOf2022()
        {
            var book = await _bookService.GetFirstBookOf2022Async();
            return Ok(new
            {
                Title = book.Title,
                YearOfPublication = book.YearOfPublication,
                Author = new
                {
                    FirstName = book.Author.FirstName,
                    LastName = book.Author.LastName
                }
            });
        }

        [HttpGet("titles-containing-metal")]
        public async Task<IActionResult> GetBooksContainingMetal()
        {
            var books = await _bookService.FindBooksByTitleContainingMetalAsync();
            return Ok(books);
        }
    }
}
