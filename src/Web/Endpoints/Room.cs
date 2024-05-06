using spacesApi.Application.Common.Models;
using spacesApi.Application.Rooms.Queries.GetRoomWithPagination;
using spacesApi.Application.Rooms.Commands.CreateRoom;
using spacesApi.Application.Rooms.Commands.DeleteRoom;
using spacesApi.Application.Rooms.Commands.UpdateRoom;
using spacesApi.Application.Rooms.Queries.GetRoomListQuery;
using spacesApi.Application.Rooms.Queries.GetRoomWithPaginationQuery;


namespace spacesApi.Web.Endpoints;

public class Room : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetRoomWithPagination)
            .MapGet(GetRoomList, "notWithPage")
            .MapPost(CreateRoom)
            .MapPut(UpdateRoom)
            .MapDelete(DeleteRoom, "{id}");
    }

    public async Task<PaginatedList<RoomWithPaginationDto>> GetRoomWithPagination(ISender sender, [AsParameters] GetRoomWithPaginationQuery query)
    {
        return await sender.Send(query);
    }
    public async Task<List<RoomDto>> GetRoomList(ISender sender, [AsParameters] GetRoomListQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<Domain.Entities.Room> CreateRoom(ISender sender, CreateRoomCommand command)
    {
        return await sender.Send(command); 
    }

    public async Task<IResult> UpdateRoom(ISender sender, UpdateRoomCommand command)
    {
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteRoom(ISender sender, int id)
    {
        await sender.Send(new DeleteRoomCommand(id));
        return Results.NoContent();
    }
}
