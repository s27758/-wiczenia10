using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ćwiczenia10.Models;

[Table("Categories")]
public class Category
{
    [Key]
    [Column("CategoryId")]
    public int CategoryId { get; set; }

    [Column("Name")]
    [MaxLength(100)]
    public string Name { get; set; }

    public ICollection<ProductsCategories> ProductsCategories { get; set; } = new List<ProductsCategories>();
}
