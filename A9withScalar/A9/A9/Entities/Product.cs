using System.Text.Json.Serialization;

namespace A9.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ProductCategoryId { get; set; }

        [JsonIgnore] //To Not Show in Swagger
        public ProductCategory? ProductCategory { get; set; }
    }
}
