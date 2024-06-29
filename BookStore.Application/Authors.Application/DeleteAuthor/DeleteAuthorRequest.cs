using Amazon.Runtime.Internal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Authors.Application.DeleteAuthor
{
    public class DeleteAuthorRequest : IRequest<DeleteAuthorResponse>
    {
        public string Id { get; set; } = string.Empty;
    }
}
