namespace spacesApi.Domain.Entities;
public class OrderGoods
{
    public int Id { get; set; }
    public int OrderId { get; set; } = 0;
    public Room Room { get; set; } = new Room();
    public Users User { get; set; } = new Users();
    public DateTime StartingTime { get; set; }
    public DateTime EndTime { get; set;}
    public DateTime CreatedDate { get; set;}

}
