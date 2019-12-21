using FluentValidation;
using MRTestProject.Models;
using System;

namespace MRTestProject.Validation
{
    public class CategoryValidation: AbstractValidator<CategoryViewModel>
    {
        public CategoryValidation()
        {
            
            RuleFor(_ => _.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);
        }
    }
}
