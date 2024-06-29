using BookStore.Data.Abstractions;
using BookStore.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Books.Application.InsertBook
{
    public class InsertBookHandler : IRequestHandler<InsertBookRequest, InsertBookResponse>
    {
        private readonly IBookRepository bookRepository;
        public InsertBookHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public async Task<InsertBookResponse> Handle(InsertBookRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var bookId = await bookRepository.InsertAsync(request.Book, cancellationToken);
                return new InsertBookResponse { message = "S-a inserat cu succes!" };
            }
            catch (Exception ex)
            {
                return new InsertBookResponse { message = "Eroare la inserare: " + ex.Message };
            }
        }
    }
}
