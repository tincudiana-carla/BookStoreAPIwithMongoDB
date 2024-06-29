using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Authors.Application.GetAuthors
{
    public class GetAuthorsResponse
    {
        public List<BookStore.Domain.Authors>? Authors { get; set; }
    }
}
