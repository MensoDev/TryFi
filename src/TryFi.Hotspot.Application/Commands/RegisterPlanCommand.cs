using FluentValidation;
using TryFi.Kernel.Domain.Messages;

namespace TryFi.Hotspot.Application.Commands
{
    public class RegisterPlanCommand : Command
    {
        public RegisterPlanCommand(string name, string upload, string download)
        {
            Name = name;
            Upload = upload;
            Download = download;
        }

        public string Name { get; private set; }
        public string Upload { get; private set; }
        public string Download { get; private set; }


        public override bool IsValid()
        {
            ValidationResult = new RegisterPlanCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    internal class RegisterPlanCommandValidator : AbstractValidator<RegisterPlanCommand>
    {
        public RegisterPlanCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage("The name must be at least three characters");

            RuleFor(x => x.Download)
                .NotEmpty()
                .WithMessage("Download rate is required");

            RuleFor(x => x.Upload)
                .NotEmpty()
                .WithMessage("Upload rate is required");
        }
    }
}
