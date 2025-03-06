using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EMS.Data.Entities.BaseEntities;


public abstract class BaseInfoEntity: BaseCommonEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("short_name")]
    [MaxLength(10)]
    [Required]
    public string ShortName { get; set; }

    [Column("full_name")]
    [MaxLength(50)]
    [Required]
    public string FullName { get; set; }
}