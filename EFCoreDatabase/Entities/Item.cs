namespace EFCoreDatabase.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();
    }
}
