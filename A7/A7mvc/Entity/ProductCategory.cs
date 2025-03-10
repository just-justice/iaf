using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace A7mvc.Entity;

[Table("product_category")]
public class ProductCategory
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsActive { get; set; }
    public DateTime? CreatedAt { get; set; }
}
