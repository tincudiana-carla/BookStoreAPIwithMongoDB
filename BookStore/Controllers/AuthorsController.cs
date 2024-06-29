using BookStore.Application.Authors.Application.DeleteAuthor;
using BookStore.Application.Authors.Application.GetAuthorById;
using BookStore.Application.Authors.Application.GetAuthors;
using BookStore.Application.Authors.Application.InsertAuthor;
using BookStore.Application.Authors.Application.UpdateAuthor;
using BookStore.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : Controller
    {
        private readonly IMediator mediator;
        public AuthorsController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet("GetAuthors")]
        public async Task<IActionResult> GetAuthors(CancellationToken token)
        {
            var response = await this.mediator.Send(new GetAuthorsRequest(), token);
            return this.Ok(response);
        }

        [HttpGet(Name = "GetAuthor/{id}")]
        public async Task<IActionResult> Get(string id, CancellationToken token)
        {
            var response = await this.mediator.Send(new GetAuthorByIdRequest { Id = id }, token);
            return this.Ok(response);
        }

        [HttpPost("InsertAuthor")]
        public async Task<IActionResult> InsertAuthor([FromBody] Authors author, CancellationToken token)
        {
            var response = await this.mediator.Send(new InsertAuthorRequest{Author = author}, token);
            return response.message == "S-a inserat cu succes!" ? Ok(response) : this.BadRequest(response);
        }

        [HttpPut("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor([FromBody] Authors author, CancellationToken token)
        {
            var response = await this.mediator.Send(new UpdateAuthorRequest { Author = author}, token);
            return response.message == "S-a realizat update cu succes!" ? Ok(response) : this.BadRequest(response) ;
        }

        [HttpDelete("DeleteAuthor/{id}")]
        public async Task<IActionResult> Delete(string id, CancellationToken token)
        {
            var response = await this.mediator.Send(new DeleteAuthorRequest { Id = id }, token);
            return response.message == "S-a realizat delete cu succes!" ? Ok(response.message) : BadRequest(response.message);
        }
    }
}
