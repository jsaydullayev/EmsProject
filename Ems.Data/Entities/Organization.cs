using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Ems.Data.Entities;

[Table("info_organization", Schema = "info")]
//[Index(nameof(Inn), IsUnique = true)]
public class Organization
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("code")]
    [MaxLength(10)]
    public string Code { get; set; }
    [Column("short_name")]
    [MaxLength(10)]
    public string ShortName { get; set; }
    [Column("full_name")]
    [MaxLength(50)]
    public string FullName { get; set; }
    [Column("address")]
    [MaxLength(100)]
    public string Address { get; set; }
    [Column("inn")]
    [MaxLength(10)]
    public string Inn { get; set; }
    [Column("director")]
    [MaxLength(50)]
    public string Director { get; set; }
    [Column("zip_code")]
    [MaxLength(15)]
    public string ZipCode { get; set; }
    [Column("phone_number")]
    [MaxLength(20)]
    public string PhoneNumber { get; set; }
    [Column("email")]
    [MaxLength(50)]
    public string Email { get; set; }
    [Column("work_schedule")]
    public string? WorkSchedule { get; set; }
    [Column("detail")]
    public string? Detail { get; set; }
    [Column("photo_url")]
    public Guid? PhotoUrl { get; set; }
    [ForeignKey("country_id")]
    public int CountryId { get; set; }
    public InfoCountry? Country { get; set; }
    [ForeignKey("city_id")]
    public int CityId { get; set; }
    public InfoCity? City { get; set; }
    [Column("district_id")]
    public int DistrictId { get; set; }
    [ForeignKey(nameof(DistrictId))]
    [InverseProperty(nameof(InfoDistrict.Organizations))]
    public InfoDistrict? District { get; set; }
    [InverseProperty(nameof(Employee.Organization))]
    public List<Employee> Employees { get; set; }
}