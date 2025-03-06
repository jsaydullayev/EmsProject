using EMS.Data.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ems.Data.Entities;

[Table("info_country", Schema = "info")]
public class InfoCountry : BaseInfoEntity
{
    [Column("code")]
    [MaxLength(10)]
    public string Code { get; set; }
}