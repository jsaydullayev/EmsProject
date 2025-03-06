using EMS.Data.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Data.Entities;
[Table("info_vacation_status", Schema ="my")]
public class VacationStatus : BaseInfoEntity
{
    [InverseProperty(nameof(VacationType.Status))]
    public List<VacationType>? VacationTypes { get; set; }
}