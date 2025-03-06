using System.ComponentModel.DataAnnotations.Schema;

namespace Ems.Data.Entities.BaseEntities;

[Table("info_contract", Schema = "info")]
public class InfoContract : BaseCommonEntity
{
    [Column("id")]
    public int Id { get; set; }
    [Column("user_id")]
    public Guid UserId { get; set; }
    [Column("status")]
    public bool Status { get; set; } = true;
}