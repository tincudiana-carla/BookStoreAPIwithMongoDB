using Amazon.Runtime.Internal;
using BookStore.Application.Books.Application.DeleteBook;
using BookStore.Data.Abstractions;
using BookStore.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Authors.Application.DeleteAuthor
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorRequest, DeleteAuthorResponse>
    {
        public readonly IAuthorRepository authorRepository;

        public DeleteAuthorHandler(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        public async Task<DeleteAuthorResponse> Handle(DeleteAuthorRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var success = await authorRepository.DeleteAsync(request.Id, cancellationToken);
                return new DeleteAuthorResponse { message = success ? "S-a realizat delete cu succes!" : "Error: Cartea nu a putut fi stearsa" };
            }
            catch (Exception ex)
            {
                return new DeleteAuthorResponse { message = "Error: " + ex.Message };
            }
        }
    }
}
