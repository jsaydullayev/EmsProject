using Ems.Data.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ems.Data.Entities;
[Table("info_work_time", Schema = "info")]
public class WorkTime : BaseInfoEntity
{
    [Column("details")]
    [MaxLength(100)]
    [Required]
    public string Details { get; set; }

    [Column("per_week_amount")]
    [Required]
    public int PerWeekAmount { get; set; }

    [Column("code")]
    [MaxLength(10)]
    public string Code { get; set; }

    [Column("job_type_id")]
    [Required]
    public int JobTypeId { get; set; }
    [ForeignKey(nameof(JobTypeId))]
    [InverseProperty(nameof(JobType.WorkTimes))]
    public JobType? JobType { get; set; }


    [Column("job_level_id")]
    [Required]
    public int JobLevelId { get; set; }
    [InverseProperty(nameof(JobLevel.WorkTimes))]
    public JobLevel? JobLevel { get; set; }
}