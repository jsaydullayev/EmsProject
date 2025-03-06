using System.ComponentModel.DataAnnotations.Schema;
using Ems.Data.Entities.BaseEntities;

namespace Ems.Data.Entities;

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