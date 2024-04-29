using spacesApi.Application.Common.Models;
using spacesApi.Application.OrderGoodss.Queries.GetOrderGoodsWithPagination;
using spacesApi.Application.OrderGoodss.Commands.CreateOrderGoods;
using spacesApi.Application.OrderGoodss.Commands.DeleteOrderGoods;
using spacesApi.Application.OrderGoodss.Queries.GitOrderGoodsWithPagination;


namespace spacesApi.Web.Endpoints;

public class OrderGoods : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetOrderGoodsWithPagination)
            .MapPost(CreateOrderGoods)
            .MapDelete(DeleteOrderGoods, "{id}");
    }

    public async Task<PaginatedList<OrderGoodsListDto>> GetOrderGoodsWithPagination(ISender sender, [AsParameters] GetOrderGoodsWithPaginationQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<OrderGoodsDto> CreateOrderGoods(ISender sender, CreateOrderGoodsCommand command)
    {
        return await sender.Send(command);
    }


    public async Task<IResult> DeleteOrderGoods(ISender sender, int id)
    {
        await sender.Send(new DeleteOrderGoodsCommand(id));
        return Results.NoContent();
    }
}
