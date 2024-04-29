using System.Text.RegularExpressions;
using System.Threading;
using FluentValidation;
using MediatR;
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
            .MustAsync(BeUniqueMoney)
            .WithMessage("用户余额不足！")
            .WithErrorCode("Unique");
        RuleFor(v => v)
            .Must(BeTime)
            .WithMessage("起始时间不能大于结束时间！")
            .WithErrorCode("Unique");
    }

    public async Task<bool> BeUniquePhoneNumber(Users users, CancellationToken cancellationToken)
    {
        return await _context.User
            .AnyAsync(l => l.PhoneNumber == users.PhoneNumber, cancellationToken: cancellationToken); ;
    }

    public async Task<bool> BeUniqueRoom(Room room, CancellationToken cancellationToken)
    {
        return await _context.Room
            .AnyAsync(l => l.Name == room.Name, cancellationToken: cancellationToken);
    }
    public async Task<bool> BeUniqueMoney(CreateOrderGoodsCommand orderGoodsCommand, CancellationToken cancellationToken)
    {
        var user = await _context.User.SingleAsync(e => e.PhoneNumber == orderGoodsCommand.User.PhoneNumber, cancellationToken: cancellationToken);
        var room = await _context.Room.SingleAsync(e => e.Id == orderGoodsCommand.Room.Id, cancellationToken: cancellationToken);
        return (orderGoodsCommand.Duration / 60 * room.Money) <= user.Money;
    }

    public static bool BeTime(CreateOrderGoodsCommand orderGoodsCommand)
    {
        return orderGoodsCommand.EndTime >= orderGoodsCommand.StartingTime;
    }
}
