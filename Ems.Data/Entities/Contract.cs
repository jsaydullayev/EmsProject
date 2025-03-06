using System.ComponentModel.DataAnnotations.Schema;
using EMS.Data.Entities.BaseEntities;

namespace EMS.Data.Entities;

[Table("contract", Schema = "my")]
public class Contract : BaseCommonEntity
{
    [Column("id")]
    public int Id { get; set; }
    [Column("contract_type_id")]
    public string ContractTypeId { get; set; }
    //public InfoContract 
    [Column("salary_id")]
    public int SalaryId { get; set; }
    //public Salary
}