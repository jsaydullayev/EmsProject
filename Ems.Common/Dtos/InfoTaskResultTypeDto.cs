namespace Ems.Common.Dtos;
public class InfoTaskResultTypeDto
{
    public int Id { get; set; }
    public string ResultType { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; } = true;
}
