using FluentValidation;

namespace InventoryApi.Business.Models.Validations
{
    public class LocationValidation : AbstractValidator<Location>
    {
        public LocationValidation()
        {
            RuleFor(f => f.Code)
                .NotEmpty().WithMessage("The field {PropertyName} must not be empty")
                .Length(2, 100)
                .WithMessage("The field {PropertyName} must have between {MinLength} e {MaxLength} characters");

            RuleFor(f => f.Address)
                .NotEmpty().WithMessage("The field {PropertyName} must not be empty")
                .Length(2, 100)
                .WithMessage("The field {PropertyName} must have between {MinLength} e {MaxLength} characters");
        }
    }
}