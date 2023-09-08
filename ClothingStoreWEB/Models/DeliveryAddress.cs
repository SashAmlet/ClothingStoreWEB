using ClothingStoreWEB.Models;

namespace ClothingStoreWEB.Models
{
    public class DeliveryAddress
    {
        public int Id { get; set; }
        public string ReceiverFName { get; set; } = null!;
        public string ReceiverLName { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string HouseNumber { get; set; } = null!;
        public int Postcode { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; }
        public string UserId { get; set; } = null!;
        public User? User { get; set; }
    }
}
