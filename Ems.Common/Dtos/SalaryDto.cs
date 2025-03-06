using EMS.Common.Dtos;

namespace Ems.Common.Dtos;
public class SalaryDto
{
    public decimal Amount { get; set; }
    public string Code { get; set; }
    public int JobTypeId { get; set; }
    public JobTypeDto JobType { get; set; }
    public int JobLevelId { get; set; }
    public JobLevelDto JobLevel { get; set; }
    public List<EmployeeDto> Employees { get; set; }
}
