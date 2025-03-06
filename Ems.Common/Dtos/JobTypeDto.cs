using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ems.Common.Dtos;

namespace Ems.Common.Dtos;
public class JobTypeDto
{
    public string Code { get; set; }
    public List<SalaryDto>? Salaries { get; set; }
    public List<WorkTimeDto>? WorkTimes { get; set; }
    public List<EmployeeDto>? Employees { get; set; }
}
