using EMS.Data.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Data.Entities;
[Table("info_task_result_type")]
public class InfoTaskResultType : BaseCommonEntity
{
    [Column("id")]
    public int Id { get; set; }
    [Column("result_type")]
    [MaxLength(50)]
    public string ResultType { get; set; }
    [Column("description")]
    public string Description {  get; set; }
    [Column("is_active")]
    public bool IsActive { get; set; } = true;
}