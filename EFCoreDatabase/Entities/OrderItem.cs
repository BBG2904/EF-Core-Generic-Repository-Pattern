namespace EFCoreDatabase.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public DateTime CreatedDate { get; set; }

        public Order? Orders { get; set; }

        public Item? Items { get; set; }
    }
}
