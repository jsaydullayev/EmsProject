using Ems.Data.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ems.Data.Entities;
[Table("info_role", Schema = "info")]
public class Role : BaseInfoEntity
{
    [Column("code")]
    [MaxLength(10)]
    [Required]
    public string Code { get; set; }
    [InverseProperty(nameof(User.Roles))]
    public List<User> Users { get; set; }
}