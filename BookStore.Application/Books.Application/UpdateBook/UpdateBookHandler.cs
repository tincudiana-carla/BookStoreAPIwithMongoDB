using Amazon.Runtime.Internal;
using BookStore.Application.Books.Application.InsertBook;
using BookStore.Data.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Books.Application.UpdateBook
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookRequest, UpdateBookResponse>
    {
        private readonly IBookRepository bookRepository;
        public UpdateBookHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public async Task<UpdateBookResponse> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var book = await bookRepository.UpdateAsync(request.Book, cancellationToken);
                return new UpdateBookResponse { message = "S-a realizat update cu succes!" };
            }
            catch (Exception ex)
            {
                return new UpdateBookResponse { message = "Eroare la update: " + ex.Message };
            }
        }
    }
}
