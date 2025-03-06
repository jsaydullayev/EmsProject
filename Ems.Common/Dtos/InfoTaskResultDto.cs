using System.ComponentModel.DataAnnotations.Schema;

namespace Ems.Common.Dtos;
public class InfoTaskResultDto
{
    public int Id { get; set; }
    public int TaskStatusId { get; set; }
    public InfoTaskStatusDto TaskStatus { get; set; }
    public Guid UserId { get; set; }
    public string ResultDescription { get; set; }
    public string ResultUrl { get; set; }
    public bool IsActive { get; set; } = true;
}
