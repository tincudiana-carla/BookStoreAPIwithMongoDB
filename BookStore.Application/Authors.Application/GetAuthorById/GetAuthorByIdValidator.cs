using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Authors.Application.GetAuthorById
{
    public class GetAuthorByIdValidator : AbstractValidator<GetAuthorByIdRequest>
    {
        public GetAuthorByIdValidator()
        {
            RuleFor(request => request.Id).NotEmpty();
        }
    }
}
