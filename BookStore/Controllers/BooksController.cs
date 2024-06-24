using BookStore.Application.DeleteBook;
using BookStore.Application.GetBookById;
using BookStore.Application.GetBooks;
using BookStore.Application.GetWeatherForecast;
using BookStore.Application.InsertBook;
using BookStore.Application.UpdateBook;
using BookStore.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator mediator;
        public BooksController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet(Name = "GetBook/{id}")]
        public async Task<IActionResult> Get(string id, CancellationToken token)
        {
            var response = await this.mediator.Send(new GetBookByIdRequest { Id = id }, token);
            return this.Ok(response);
        }


        [HttpGet("GetBooks")]
        public async Task<IActionResult> GetBooks(CancellationToken token)
        {
            var response = await this.mediator.Send(new GetBooksRequest(), token);
            return this.Ok(response);
        }
        

        [HttpPost("InsertBook")]
        public async Task<IActionResult> Insert([FromBody] Book book, CancellationToken token)
        {
            var response = await this.mediator.Send(new InsertBookRequest { Book = book }, token);
            return response.message == "S-a inserat cu succes!" ? Ok(response.message) : BadRequest(response.message); 
        }


        [HttpPut("UpdateBook")]
        public async Task<IActionResult> Update([FromBody] Book book, CancellationToken token)
        {
            var response = await this.mediator.Send(new UpdateBookRequest { Book = book }, token);
            return response.message == "S-a realizat update cu succes!" ? Ok(response.message) : BadRequest(response.message);
        }


        [HttpDelete("DeleteBook")]
        public async Task<IActionResult> Delete(string id, CancellationToken token)
        {
            var response = await this.mediator.Send(new DeleteBookRequest { Id = id }, token);
            return response.message == "S-a realizat delete cu succes!" ? Ok(response.message) : BadRequest(response.message);
        }

    }
}
