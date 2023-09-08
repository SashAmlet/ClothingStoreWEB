using ClothingStoreWEB.Models.AuxiliaryModels;

namespace ClothingStoreWEB.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public int? StatusId { get; set; }
        public int? PaymentId { get; set; }
        public int? DeliveryId { get; set; }
        public string Comment { get; set; } = string.Empty;

        public IEnumerable<ItemOrder>? ItemOrders { get; set; }
        public User? User { get; set; }
        public Status? Status { get; set; }
        public Payment? Payment { get; set; }
        public Delivery? Delivery { get; set; }
    }
}
