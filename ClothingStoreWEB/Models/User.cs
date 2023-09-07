namespace ClothingStore.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FName { get; set; } = null!;
        public string LName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!; 

        public IEnumerable<Order>? Orders { get; set; }
    }
}
