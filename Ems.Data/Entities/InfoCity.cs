using EMS.Data.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ems.Data.Entities;

[Table("info_city", Schema = "info")]
public class InfoCity : BaseInfoEntity
{
    [Column("code")]
    public string Code { get; set; }
    [Column("country_id")]
    [Required]
    public int InfoCountryId { get; set; }
    [ForeignKey(nameof(InfoCountryId))]
    public InfoCountry? InfoCountry { get; set; }
    [InverseProperty(nameof(Employee.City))]
    public List<Employee> Employees { get; set; }
}