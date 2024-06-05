using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ćwiczenia10.Models;

[Table("Accounts")]
public class Account
{
    [Key]
    [Column("AccountId")]
    public int AccountId { get; set; }

    [ForeignKey("Role")]
    [Column("RoleId")]
    public int RoleId { get; set; }

    [Column("FirstName")]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Column("LastName")]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Column("Email")]
    [MaxLength(80)]
    public string Email { get; set; }

    [Column("Phone")]
    [MaxLength(9)]
    public string Phone { get; set; }

    public Role Role { get; set; }
    public ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
}
