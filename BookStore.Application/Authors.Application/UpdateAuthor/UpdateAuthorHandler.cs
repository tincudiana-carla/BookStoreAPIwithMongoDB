using BookStore.Application.Books.Application.UpdateBook;
using BookStore.Data.Abstractions;
using BookStore.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Authors.Application.UpdateAuthor
{
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorRequest, UpdateAuthorResponse>
    {
        public readonly IAuthorRepository authorRepository;
        public UpdateAuthorHandler(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        public async Task<UpdateAuthorResponse> Handle(UpdateAuthorRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var book = await authorRepository.UpdateAsync(request.Author, cancellationToken);
                return new UpdateAuthorResponse { message = "S-a realizat update cu succes!" };
            }
            catch (Exception ex)
            {
                return new UpdateAuthorResponse { message = "Eroare la update: " + ex.Message };
            }
        }
    }
}
