using Ems.Data.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ems.Data.Entities;

namespace Ems.Data.Entities;
[Table("info_salary", Schema ="info")]
public class Salary : BaseInfoEntity
{

    [Column("amount", TypeName = "decimal(18,2)")]
    [Required]
    public decimal Amount { get; set; }

    [MaxLength(10)]
    [Required]
    [Column("code")]
    public string Code { get; set; }
    [Column("job_type_id")]
    [Required]
    public int JobTypeId { get; set; }
    [ForeignKey(nameof(JobTypeId))]
    [InverseProperty(nameof(JobType.Salaries))]
    public JobType JobType { get; set; }

    [Column("job_level_id")]
    [Required]
    public int JobLevelId { get; set; }

    [ForeignKey(nameof(JobLevelId))]
    [InverseProperty(nameof(JobLevel.Salaries))]
    public JobLevel JobLevel { get; set; }

    [InverseProperty(nameof(Employee.Salary))]
    public List<Employee> Employees { get; set; }
}