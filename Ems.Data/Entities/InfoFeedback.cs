using Ems.Data.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ems.Data.Entities;
[Table("info_feedback", Schema = "info")]
public class InfoFeedback : BaseCommonEntity
{
    [Column("id")]
    public int Id { get; set; }
    [Column("text")]
    public string Text { get; set; }
    [Column("is_read")]
    public bool IsRead { get; set; } = false;
}