using ClothingStore.Models.AuxiliaryModels;

namespace ClothingStore.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public int? ManufacturerId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        public Category? Category { get; set; }
        public IEnumerable<ItemOrder>? ItemOrders { get; set; }
        public Manufacture? Manufacture { get; set; }
        
    }
}
