﻿using FluentValidation;

namespace InventoryApi.Business.Models.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("The field {PropertyName} must not be empty")
                .Length(2, 200).WithMessage("The field {PropertyName} must have between {MinLength} and {MaxLength} characters");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("The field {PropertyName} must not be empty")
                .Length(2, 1000).WithMessage("The field {PropertyName} must have between {MinLength} and {MaxLength} characters");

            RuleFor(c => c.Price)
                .GreaterThan(0).WithMessage("The field {PropertyName} must be greater than {ComparisonValue}");
        }
    }
}