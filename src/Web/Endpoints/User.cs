using spacesApi.Application.Common.Models;
using spacesApi.Application.User.Commands.CreateUser;
using spacesApi.Application.User.Commands.DeleteUser;
using spacesApi.Application.User.Commands.UpdateUser;
using spacesApi.Application.User.Commands.UpdateUserMoney;
using spacesApi.Application.User.Queries.GetUser;
using spacesApi.Application.User.Queries.GetUsersWithPagination;

namespace spacesApi.Web.Endpoints;

public class User : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetUserList)
            .MapGet(GetUser, "{PhoneNumber}")
            .MapPost(CreateUser)
            .MapPut(UpdateUser)
            .MapPut(UpdateMoney,"updatemoney")
            .MapDelete(DeleteUser, "{id}");
    }

    public async Task<PaginatedList<Domain.Entities.Users>> GetUserList(ISender sender, [AsParameters] GetUsersWithPagination query)
    {
        return await sender.Send(query);
    }

    public async Task<Domain.Entities.Users> GetUser(ISender sender, [AsParameters] GetUserQuery query)
    {
        Domain.Entities.Users users = new Domain.Entities.Users();
        users = await sender.Send(query);
        return users;
    }

    public async Task<long> CreateUser(ISender sender, CreateUserCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateUser(ISender sender, UpdateUserCommand command)
    {
        await sender.Send(command);
        return Results.NoContent();
    }
    public async Task<IResult> UpdateMoney(ISender sender, UpdateUserMoneyCommand command)
    {
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteUser(ISender sender, int id)
    {
        await sender.Send(new DeleteUserCommand(id));
        return Results.NoContent();
    }
}
