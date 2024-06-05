using System.ComponentModel.DataAnnotations.Schema;

namespace Ćwiczenia10.Models;

[Table("Shopping_Carts")]
public class ShoppingCart
{
    [ForeignKey("Account")]
    [Column("AccountId")]
    public int AccountId { get; set; }

    [ForeignKey("Product")]
    [Column("ProductId")]
    public int ProductId { get; set; }

    [Column("Amount")]
    public int Amount { get; set; }

    public Account Account { get; set; }
    public Product Product { get; set; }
}
