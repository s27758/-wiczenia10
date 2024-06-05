using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ćwiczenia10.Models;
[Table("Roles")]
public class Role
{
    [Key]
    [Column("RoleId")]
    public int RoleId { get; set; }

    [Column("Name")]
    [MaxLength(100)]
    public string Name { get; set; }

    public ICollection<Account> Accounts { get; set; } = new List<Account>();
}
