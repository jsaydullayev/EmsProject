using Ems.Common.Dtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ems.Common.Dtos;
public class FeedbackDto
{
    public int Id { get; set; }
    public Guid FromUserId { get; set; }
    public Guid ToUserId { get; set; }
    public UserDto User { get; set; }
}
