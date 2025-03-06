using EMS.Common.Dtos;

namespace Ems.Common.Dtos;
public class JobLevelDto
{
    public string Code { get; set; }
    public List<SalaryDto>? Salaries { get; set; }
    public List<WorkTimeDto>? WorkTimes { get; set; }
    public List<EmployeeDto>? Employees { get; set; }
}
