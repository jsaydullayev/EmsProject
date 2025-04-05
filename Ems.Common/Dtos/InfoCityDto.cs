using Ems.Common.Dtos;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ems.Common.Dtos;
public class InfoCityDto : BaseInfoDto
{
    public int InfoCountryId { get; set; }
    public InfoCountryDto? InfoCountry { get; set; }
    public List<EmployeeDto> Employees { get; set; }
}
