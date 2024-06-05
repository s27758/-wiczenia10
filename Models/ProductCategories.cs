using System.ComponentModel.DataAnnotations.Schema;

namespace Ćwiczenia10.Models;

[Table("Products_Categories")]
public class ProductsCategories
{
    [ForeignKey("Product")]
    [Column("ProductId")]
    public int ProductId { get; set; }

    [ForeignKey("Category")]
    [Column("CategoryId")]
    public int CategoryId { get; set; }

    public Product Product { get; set; }
    public Category Category { get; set; }
}
