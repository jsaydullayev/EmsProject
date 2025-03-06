using System.ComponentModel.DataAnnotations.Schema;
using EMS.Data.Entities.BaseEntities;

namespace EMS.Data.Entities;
[Table("info_gender", Schema ="info")]
public class Gender : BaseInfoEntity
{
}