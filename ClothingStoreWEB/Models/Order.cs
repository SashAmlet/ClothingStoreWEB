using ClothingStore.Models.AuxiliaryModels;

namespace ClothingStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
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
