using spacesApi.Application.Common.Models;
using spacesApi.Application.User.Commands.CreateUser;
using spacesApi.Application.User.Commands.DeleteUser;
using spacesApi.Application.User.Commands.UpdateUser;
using spacesApi.Application.User.Commands.UpdateUserMoney;
using spacesApi.Application.User.Queries.GetUser;

namespace spacesApi.Web.Endpoints;

public class User : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetUser,"{PhoneNumber}")
            .MapPost(CreateUser)
            .MapPut(UpdateUser, "{PhoneNumber}")
            .MapDelete(DeleteUser, "{id}");
    }

    public async Task<Domain.Entities.Users> GetUser(ISender sender, [AsParameters] GetUserQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<long> CreateUser(ISender sender, CreateUserCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateUser(ISender sender, int id, UpdateUserCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }


    public async Task<IResult> DeleteUser(ISender sender, int id)
    {
        await sender.Send(new DeleteUserCommand(id));
        return Results.NoContent();
    }
}
