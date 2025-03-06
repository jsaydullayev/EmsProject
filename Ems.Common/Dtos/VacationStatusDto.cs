using EMS.Common.Dtos;

namespace Ems.Common.Dtos;
public class VacationStatusDto : BaseInfoDto
{

    public List<VacationTypeDto>? VacationTypes { get; set; }
}
