using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookStore.Application.GetBooks
{
    public class GetBooksRequest : IRequest<GetBooksResponse>
    {
    }
}
