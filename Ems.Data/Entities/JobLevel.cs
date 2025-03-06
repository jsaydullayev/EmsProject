using EMS.Data.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ems.Data.Entities;

namespace EMS.Data.Entities;
[Table("info_job_level", Schema ="info")]
public class JobLevel : BaseInfoEntity
{

    [MaxLength(10)]
    [Required]
    [Column("code")]
    public string Code { get; set; }
    
    [InverseProperty(nameof(Salary.JobLevel))]
    public List<Salary>? Salaries { get; set; }

    [InverseProperty(nameof(WorkTime.JobLevel))]
    public List<WorkTime>? WorkTimes { get; set; }

    [InverseProperty(nameof(Employee.JobLevel))]
    public List<Employee>? Employees { get; set; }
}