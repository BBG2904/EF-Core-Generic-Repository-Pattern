using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreDatabase.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ShopId {  get; set; }
        public Shop? Shop { get; set; }

        public List<OrderItem>? OrderItems { get; set; }
    }
}
