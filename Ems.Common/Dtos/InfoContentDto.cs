namespace EMS.Common.Dtos;

public class InfoContentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string FileUrl { get; set; }
    public int? TaskId { get; set; }
    public int ContentTypeId { get; set; }
    public InfoContentTypeDto? ContentType { get; set; }
}