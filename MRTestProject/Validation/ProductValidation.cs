using FluentValidation;
using MRTestProject.Models;

namespace MRTestProject.Validation
{
    public class ProductValidation : AbstractValidator<ProductViewModel>
    {
        public ProductValidation()
        {
            RuleFor(_ => _.Price).NotNull();
            RuleFor(_ => _.Description).MaximumLength(1000);

            RuleFor(_ => _.Name)
                .NotNull()
                .MaximumLength(100);
        }
    }
}
