using System.ComponentModel.DataAnnotations.Schema;
using Ems.Data.Entities.BaseEntities;

namespace Ems.Data.Entities;
[Table("info_gender", Schema ="info")]
public class Gender : BaseInfoEntity
{
    [InverseProperty(nameof(User.Gender))]
    public List<User>? Users { get; set; }
}