using System.ComponentModel.DataAnnotations.Schema;

namespace Ems.Common.Dtos;
public class InfoFeedback
{
    public int Id { get; set; }
    public string Text { get; set; }
    public bool IsRead { get; set; } = false;
}
