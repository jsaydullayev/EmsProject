using System.ComponentModel.DataAnnotations.Schema;

namespace Ems.Data.Entities.BaseEntities;
public abstract class BaseCommonEntity
{

    [Column("created_date")]
    public DateTime CreatedDate { get; set; }
    [Column("updated_date")]
    public DateTime? UpdatedDate { get; set; }
}