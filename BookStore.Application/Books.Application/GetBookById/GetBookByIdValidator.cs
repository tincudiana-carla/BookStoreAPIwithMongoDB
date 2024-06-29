using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Books.Application.GetBookById
{
    public class GetBookByIdValidator : AbstractValidator<GetBookByIdRequest>
    {
        public GetBookByIdValidator()
        {

            RuleFor(request => request.Id).NotEmpty();

        }
    }
}
