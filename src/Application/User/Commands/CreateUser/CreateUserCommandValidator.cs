using System.Text.RegularExpressions;
using spacesApi.Application.Common.Interfaces;

namespace spacesApi.Application.User.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateUserCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.PhoneNumber)
            .NotEmpty()
            .MustAsync(BeUniquePhoneNumber)
                .WithMessage("手机号码已注册！")
                .WithErrorCode("Unique")
            .Must(BeFormatPhoneNumber)
                .WithMessage("手机号码格式不正确！")
                .WithErrorCode("Format");
    }

    public async Task<bool> BeUniquePhoneNumber(long PhoneNumber, CancellationToken cancellationToken)
    {
        return await _context.User
            .AllAsync(l => l.PhoneNumber != PhoneNumber, cancellationToken);
    }

    public bool BeFormatPhoneNumber(long PhoneNumber)
    {
        return Regex.IsMatch(PhoneNumber.ToString(), @"^1[0-9]{10}");
    }
}
