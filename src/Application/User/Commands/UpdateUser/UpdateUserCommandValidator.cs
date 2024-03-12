using System.Text.RegularExpressions;
using spacesApi.Application.Common.Interfaces;
using spacesApi.Domain.Entities;

namespace spacesApi.Application.User.Commands.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateUserCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v)
            .NotEmpty()
            .MustAsync(BeUniquePhoneNumber)
                .WithMessage("'{PropertyName}'已注册！")
                .WithErrorCode("Unique")
            .Must(BeFormatPhoneNumber)
                .WithMessage("手机号码格式不正确！")
                .WithErrorCode("Format");
    }

    public async Task<bool> BeUniquePhoneNumber(UpdateUserCommand users, CancellationToken cancellationToken)
    {
        return await _context.User.AnyAsync(x => x.Id == users.Id && x.PhoneNumber == users.PhoneNumber)
            || await _context.User.AllAsync(l => l.PhoneNumber != users.PhoneNumber, cancellationToken);
    }

    public bool BeFormatPhoneNumber(UpdateUserCommand users)
    {
        return Regex.IsMatch(users.PhoneNumber.ToString(), @"^1[0-9]{10}");
    }
}
