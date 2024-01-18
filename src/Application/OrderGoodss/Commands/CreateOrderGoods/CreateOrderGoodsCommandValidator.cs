using System.Text.RegularExpressions;
using spacesApi.Application.Common.Interfaces;
using spacesApi.Domain.Entities;

namespace spacesApi.Application.OrderGoodss.Commands.CreateOrderGoods;

public class CreateOrderGoodsCommandValidator : AbstractValidator<CreateOrderGoodsCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateOrderGoodsCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.User)
            .NotEmpty()
            .MustAsync(BeUniquePhoneNumber)
                .WithMessage("手机号码不存在！")
                .WithErrorCode("Unique");
        RuleFor(v => v.Room)
            .NotEmpty()
            .MustAsync(BeUniqueRoom)
                .WithMessage("房间信息错误！")
                .WithErrorCode("Unique");
        RuleFor(v => v)
            .Must(BeTime)
            .WithMessage("起始时间不能大于结束时间！")
            .WithErrorCode("Unique");
    }

    public async Task<bool> BeUniquePhoneNumber(Users users, CancellationToken cancellationToken)
    {
        return await _context.User
            .AllAsync(l => l.PhoneNumber == users.PhoneNumber, cancellationToken);
    }

    public async Task<bool> BeUniqueRoom(Room room, CancellationToken cancellationToken)
    {
        return await _context.Room
            .AllAsync(l => l.Name == room.Name, cancellationToken);
    }

    public bool BeTime(CreateOrderGoodsCommand orderGoodsCommand)
    {
        return orderGoodsCommand.EndTime > orderGoodsCommand.StartingTime;
    }
}
