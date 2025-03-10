using System;

namespace A7mvc.Entity;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public DateTime? CreatedAt { get; set; }
    public int CategoryId { get; set; }
    public ProductCategory Category { get; set; } //NAVIGATION PROPERTY
}
