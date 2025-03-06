namespace Ems.Common.Dtos;
public class InfoTaskStatusDto
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string TaskName { get; set; }
    public string? TaskUrl { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; } = true;
}
