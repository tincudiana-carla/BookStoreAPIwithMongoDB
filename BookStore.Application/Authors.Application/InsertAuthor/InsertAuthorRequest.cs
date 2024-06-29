using Amazon.Runtime.Internal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Authors.Application.InsertAuthor
{
    public class InsertAuthorRequest : IRequest<InsertAuthorResponse>
    {
        public BookStore.Domain.Authors? Author { get; set; }
    }
}
