using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Data.Entities.BaseEntities;

namespace EMS.Data.Entities;

[Table("info_content_type", Schema = "info")]
public class InfoContentType: BaseCommonEntity
{
    [Column("id")]
    [Key]
    public int Id { get; set; }
    [Column("short_name")]
    [MaxLength(10)]
    public string ShortName {  get; set; }
    [Column("full_name")]
    [MaxLength(50)]
    public string FullName { get; set; }
    
    [Column("type_name")]
    public string TypeName { get; set; }
}