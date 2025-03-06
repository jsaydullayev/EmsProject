using Ems.Common.Dtos;
namespace Ems.Common.Dtos;
public class WorkTimeDto : BaseInfoDto
{
    public string Details { get; set; }
    public int PerWeekAmount { get; set; }
    public string Code { get; set; }
    public int JobTypeId { get; set; }
    public JobTypeDto? JobType { get; set; }
    public int JobLevelId { get; set; } 
    public JobLevelDto? JobLevel { get; set; }
}
