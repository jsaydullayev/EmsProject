using Ems.Data.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ems.Data.Entities;
[Table("info_vacation_type", Schema ="my")]
public class VacationType : BaseInfoEntity
{
    [Column("code")]
    [MaxLength(10)]
    public string Code { get; set; }

    [Column("duration")]
    [MaxLength(50)]
    [Required]
    public string Duration { get; set; }

    [Column("status_id")]
    [Required]
    public int StatusId { get; set; }
    [ForeignKey(nameof(StatusId))]
    [InverseProperty(nameof(VacationStatus.VacationTypes))]
    public VacationStatus? Status { get; set; }
}