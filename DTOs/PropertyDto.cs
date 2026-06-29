namespace RealEstate.Api.DTOs
{
    public class PropertyDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Address { get; set; } = string.Empty;
        public int Area { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}