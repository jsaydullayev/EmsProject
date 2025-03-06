using System.ComponentModel.DataAnnotations.Schema;

namespace Ems.Common.Dtos;
public class ContractDto
{
    public int Id { get; set; }
    public string ContractTypeId { get; set; }
    public int SalaryId { get; set; }
}
