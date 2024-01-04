using spacesApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace spacesApi.Infrastructure.Data.Configurations;

public class OrderGoodsConfiguration : IEntityTypeConfiguration<OrderGoods>
{
    public void Configure(EntityTypeBuilder<OrderGoods> builder)
    {
    }
}
