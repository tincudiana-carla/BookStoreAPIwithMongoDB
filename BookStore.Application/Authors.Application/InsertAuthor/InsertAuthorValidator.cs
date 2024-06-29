using BookStore.Application.Books.Application.InsertBook;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Authors.Application.InsertAuthor
{
    public class InsertAuthorValidator : AbstractValidator<InsertBookRequest>
    {
    }
}
