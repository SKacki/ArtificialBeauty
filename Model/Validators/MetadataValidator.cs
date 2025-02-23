using FluentValidation;
using Model.Models;

public class MetadataValidator : AbstractValidator<MetadataDTO>
{
    public MetadataValidator()
    {
        RuleFor(x => x.ModelId)
          .NotNull()
          .NotEmpty()
          .WithMessage("Model is Required.");


        When(x => x.Lora1Id.HasValue, () =>
        {
            RuleFor(x => x.Lora1Weight)
            .NotEmpty()
            .NotNull()
            .WithMessage("Model weight is required");
        });
    }
}