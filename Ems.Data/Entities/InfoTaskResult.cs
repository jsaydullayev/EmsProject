using Ems.Data.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ems.Data.Entities;

[Table("info_task_result", Schema = "info")]
public class InfoTaskResult : BaseCommonEntity
{
    [Column("id")]
    public int Id { get; set; }
    [Column("task_status_id")]
    public int TaskStatusId { get; set; }
    [InverseProperty(nameof(InfoTaskStatus.Id))]
    public InfoTaskStatus TaskStatus { get; set; }
    
    [Column("user_id")]
    public Guid UserId{ get; set; }
    [Column("result_description")]
    public string ResultDescription { get; set; }
    [Column("result_url")]
    public string ResultUrl { get; set; }
    [Column("is_active")]
    public bool IsActive { get; set; } = true;
}