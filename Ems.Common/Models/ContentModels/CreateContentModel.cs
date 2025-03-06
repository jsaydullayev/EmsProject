namespace EMS.Common.Models.ContentModels;

public class CreateContentModel
{
    public required string Name { get; set; }
    public required string FileUrl { get; set; }
    public int ContentTypeId { get; set; }
}