using BookStore.Application.Books.Application.InsertBook;
using BookStore.Data.Abstractions;
using BookStore.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Authors.Application.InsertAuthor
{
    public class InsertAuthorHandler : IRequestHandler<InsertAuthorRequest, InsertAuthorResponse>
    {
        public readonly IAuthorRepository authorRepository;
        public InsertAuthorHandler(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        public async Task<InsertAuthorResponse> Handle(InsertAuthorRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var bookId = await authorRepository.InsertAsync(request.Author, cancellationToken);
                return new InsertAuthorResponse { message = "S-a inserat cu succes!" };
            }
            catch (Exception ex)
            {
                return new InsertAuthorResponse { message = "Eroare la inserare: " + ex.Message };
            }
        }
    }
}
