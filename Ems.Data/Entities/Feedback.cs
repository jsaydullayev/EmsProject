using System.ComponentModel.DataAnnotations.Schema;
using Ems.Data.Entities;
using Ems.Data.Entities.BaseEntities;

namespace Ems.Data.Entities;

[Table("feedback", Schema = "my")]
public class Feedback : BaseCommonEntity
{
    [Column("id")]
    public int Id { get; set; }

    [ForeignKey("from_user_id")]
    public Guid FromUserId { get; set; }
    [ForeignKey("to_user_id")]
    public Guid ToUserId { get; set; }
    public User User { get; set; }
}