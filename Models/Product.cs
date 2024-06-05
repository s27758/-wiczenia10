using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ćwiczenia10.Models;

[Table("Products")]
public class Product
{
    [Key]
    [Column("ProductId")]
    public int ProductId { get; set; }

    [Column("Name")]
    [MaxLength(100)]
    public string Name { get; set; }

    [Column("Weight")]
    public decimal Weight { get; set; }

    [Column("Width")]
    public decimal Width { get; set; }

    [Column("Height")]
    public decimal Height { get; set; }

    [Column("Depth")]
    public decimal Depth { get; set; }

    public ICollection<ProductsCategories> ProductsCategories { get; set; } = new List<ProductsCategories>();
    public ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
}
