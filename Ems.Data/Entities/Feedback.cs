using System.ComponentModel.DataAnnotations.Schema;
using Ems.Data.Entities;
using EMS.Data.Entities.BaseEntities;

namespace EMS.Data.Entities;

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