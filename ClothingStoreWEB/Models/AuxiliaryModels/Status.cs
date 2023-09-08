namespace ClothingStoreWEB.Models.AuxiliaryModels
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<Order>? Orders { get; set; }
    }
}
