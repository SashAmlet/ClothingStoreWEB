using ClothingStoreWEB.Models;
using Microsoft.AspNetCore.Identity;

namespace ClothingStoreWEB.Models
{
    public class User: IdentityUser
    {
        public string FName { get; set; } = null!;
        public string LName { get; set; } = null!;
        public IEnumerable<Order>? Orders { get; set; }
        public IEnumerable<DeliveryAddress>? DeliveryAddresses { get; set; }
    }
}
