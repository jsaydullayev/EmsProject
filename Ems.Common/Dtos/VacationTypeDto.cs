using EMS.Common.Dtos;

namespace Ems.Common.Dtos;
public class VacationTypeDto : BaseInfoDto
{
    public string Code { get; set; }
    public string Duration { get; set; }
    public int StatusId { get; set; }
    public VacationStatusDto? Status { get; set; }
}
