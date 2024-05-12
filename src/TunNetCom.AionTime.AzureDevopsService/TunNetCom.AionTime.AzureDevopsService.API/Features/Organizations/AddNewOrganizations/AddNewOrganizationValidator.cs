namespace TunNetCom.AionTime.AzureDevopsService.API.Features.Organizations.AddNewOrganizations;

public class AddNewOrganizationValidator : AbstractValidator<AddNewOrganizationCommand>
{
    public AddNewOrganizationValidator()
    {
        _ = RuleFor(org => org.Name)
            .NotNull()
            .WithMessage("Organization name cannot be null.")
            .NotEmpty()
            .WithMessage("Organization name cannot be empty.")
            .MaximumLength(255)
            .WithMessage("Organization length cannot be heigher than 255.");
    }
}