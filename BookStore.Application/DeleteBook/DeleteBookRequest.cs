using Amazon.Runtime.Internal;
using BookStore.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DeleteBook
{
    public class DeleteBookRequest : IRequest<DeleteBookResponse>
    {
        public string Id { get; set; } = string.Empty;
    }
}
