using EMS.Data.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ems.Data.Entities;

[Table("info_district", Schema = "info")]
public class InfoDistrict : BaseInfoEntity
{
    [Column("code")]
    [MaxLength(10)]
    public string Code { get; set; }
    [InverseProperty(nameof(Organization.District))]
    public List<Organization>? Organizations { get; set; }
    [InverseProperty(nameof(Employee.District))]
    public List<Employee> Employees { get; set; }
}