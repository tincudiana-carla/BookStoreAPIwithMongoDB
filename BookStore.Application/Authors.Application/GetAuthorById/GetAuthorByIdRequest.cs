using BookStore.Application.Books.Application.GetBookById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Authors.Application.GetAuthorById
{
    public class GetAuthorByIdRequest : IRequest<GetAuthorByIdResponse>
    {
        public string Id { get; set; } = string.Empty;
    }
}
