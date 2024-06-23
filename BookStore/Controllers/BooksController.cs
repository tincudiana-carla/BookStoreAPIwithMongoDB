using BookStore.Application.GetBookById;
using BookStore.Application.GetWeatherForecast;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> Get(string id,CancellationToken token)
    {
      var response = await this.mediator.Send(new GetBookByIdRequest {Id = id }, token);
      return this.Ok(response);
    }

    /*
     * GetAllAsync
     * InsertAsync
     * DeleteAsync
     * UpdateAsync
     */
  }
}
