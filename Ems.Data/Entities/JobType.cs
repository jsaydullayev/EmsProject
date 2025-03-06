using EMS.Data.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ems.Data.Entities;

namespace EMS.Data.Entities;
[Table("info_job_type",Schema ="info")]
public class JobType : BaseInfoEntity
{
    [MaxLength(10)]
    [Required]
    [Column("code")]
    public string Code { get; set; }

    [InverseProperty(nameof(Salary.JobType))]
    public List<Salary>? Salaries { get; set; }
    [InverseProperty(nameof(WorkTime.JobType))]
    public List<WorkTime>? WorkTimes { get; set; }
    [InverseProperty(nameof(Employee.JobType))]
    public List<Employee>? Employees { get; set; }
}