using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ems.Common.Dtos;

namespace Ems.Common.Dtos;
public class OrganizationDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public string Inn { get; set; }
    public string Director { get; set; }
    public string ZipCode { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string? WorkSchedule { get; set; }
    public string? Detail { get; set; }
    public Guid? PhotoUrl { get; set; }
    public int CountryId { get; set; }
    public InfoCountryDto? Country { get; set; }
    public int CityId { get; set; }
    public InfoCityDto? City { get; set; }
    public int DistrictId { get; set; }
    public InfoDistrictDto? District { get; set; }
    public List<EmployeeDto> Employee { get; set; }
}
