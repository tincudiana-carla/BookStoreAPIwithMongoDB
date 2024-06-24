using BookStore.Data.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DeleteBook
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookRequest, DeleteBookResponse>
    {

        private readonly IBookRepository bookRepository;

        public DeleteBookHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public async Task<DeleteBookResponse> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var success = await this.bookRepository.DeleteAsync(request.Id, cancellationToken);
                return new DeleteBookResponse { message = success ? "S-a realizat delete cu succes!" : "Error: Cartea nu a putut fi stearsa" };
            }
            catch (Exception ex)
            {
                return new DeleteBookResponse { message = "Error: " + ex.Message };
            }
        }
    }
}
