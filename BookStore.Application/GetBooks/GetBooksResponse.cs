using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.GetBooks
{
    public class GetBooksResponse
    {
        public List<Book>? Books { get; set; }
    }
}
