using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Authors.Application.DeleteAuthor
{
    public class DeleteAuthorValidator : AbstractValidator<DeleteAuthorRequest>
    {
        public DeleteAuthorValidator()
        {
            RuleFor(request => request.Id).NotEmpty();
        }
    }
}
