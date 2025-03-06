using Ems.Data.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ems.Data.Entities;

[Table("info_task_status", Schema = "info")]
public class InfoTaskStatus : BaseCommonEntity
{
    [Column("id")]
    public int Id { get; set; }
    [Column("user_id")]
    public Guid UserId { get; set; }
    //public User User { get; set;}
    [Column("task_name")]
    [MaxLength(100)]
    public string TaskName { get; set; }
    [Column("task_url")]
    public string? TaskUrl { get; set; }
    [Column("status")]
    [MaxLength (50)]
    public string Status { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("is_active")]
    public bool IsActive { get; set; } = true;
}