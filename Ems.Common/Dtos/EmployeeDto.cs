using Ems.Common.Dtos;

namespace EMS.Common.Dtos;

public class EmployeeDto
{
    public int Id { get; set; }

    public Guid UserId { get; set; }
    public UserDto? User { get; set; }
    
    public int OrganizationId { get; set; }
    public OrganizationDto? Organization { get; set; }

    public int JobTypeId { get; set; }
    public JobTypeDto? JobType { get; set; }

    public int JobLevelId { get; set; }

    public JobLevelDto? JobLevel { get; set; }

    public int SalaryId { get; set; }
    public SalaryDto? Salary { get; set; }

    public int CountryId { get; set; }

    public InfoCountryDto? Country { get; set; }

    public int CityId { get; set; }
    public InfoCityDto? City { get; set; }

    public int DistrictId { get; set; }
    public InfoDistrictDto? District { get; set; }
}