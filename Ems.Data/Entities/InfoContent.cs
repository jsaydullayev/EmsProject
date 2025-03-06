using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ems.Data.Entities.BaseEntities;

namespace Ems.Data.Entities;

[Table("info_content", Schema = "info")]
public class InfoContent: BaseCommonEntity
{
    [Column("id")]
    [MaxLength(3)]
    [Key]
    public int Id { get; set; }
    [Column("name")]
    [MaxLength(10)]
    public string Name { get; set; }
    [Column("file_url")]
    [Required]
    public string FileUrl { get; set; }
    [Column("task_id")]
    public int? TaskId { get; set; }
    //public MyTask { get; set; }
    
    [Column("content_type_id")]
    public int ContentTypeId { get; set; }
    [ForeignKey(nameof(ContentTypeId))]
    public InfoContentType? ContentType { get; set; }
}