namespace ClothingStore.Models.AuxiliaryModels
{
    public class Delivery
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<Order>? Orders { get; set; }
    }
}
