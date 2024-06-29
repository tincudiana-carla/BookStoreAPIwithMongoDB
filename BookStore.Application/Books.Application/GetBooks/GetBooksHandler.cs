using BookStore.Data.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Books.Application.GetBooks
{
    public class GetBooksHandler : IRequestHandler<GetBooksRequest, GetBooksResponse>
    {

        private readonly IBookRepository bookRepository;

        public GetBooksHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<GetBooksResponse> Handle(GetBooksRequest request, CancellationToken cancellationToken)
        {
            var books = await bookRepository.GetAllAsync(cancellationToken);
            return new GetBooksResponse { Books = books };
        }
    }
}
