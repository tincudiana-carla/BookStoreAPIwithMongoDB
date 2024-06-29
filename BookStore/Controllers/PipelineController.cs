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
    }
}
