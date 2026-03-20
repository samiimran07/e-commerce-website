namespace ecommerce_website.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public string? ImageName { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
    }
}