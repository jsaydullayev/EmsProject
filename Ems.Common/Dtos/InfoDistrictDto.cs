using EMS.Common.Dtos;
namespace Ems.Common.Dtos;
public class InfoDistrictDto : BaseInfoDto
{

    public string Code { get; set; }
    public List<OrganizationDto>? Organizations { get; set; }
    public List<EmployeeDto> Employees { get; set; }
}
