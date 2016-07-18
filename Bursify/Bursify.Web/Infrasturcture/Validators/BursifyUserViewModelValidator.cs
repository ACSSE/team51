using Bursify.Web.Models;
using FluentValidation;

namespace Bursify.Web.Infrasturcture.Validators
{
    public class BursifyUserViewModelValidator : AbstractValidator<BursifyUserViewModel>
    {
        public BursifyUserViewModelValidator()
        {
            RuleFor(bursifyuser => bursifyuser.Name).NotEmpty();
            RuleFor(bursifyuser => bursifyuser.Email).NotEmpty().EmailAddress();
        }
    }
}