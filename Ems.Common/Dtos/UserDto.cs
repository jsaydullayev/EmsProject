namespace Ems.Common.Dtos;

public class UserDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string FullName { get; set; }
    public string Username { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public Guid CreatedUserId { get; set; }
    public int RoleId { get; set; }
    public RoleDto? Role { get; set; }
    public int GenderId { get; set; }
    public GenderDto? Gender { get; set; }
    public int ContentId { get; set; }
    public InfoContentDto? Content { get; set; }
    public int StateId { get; set; }
    public StateDto? State { get; set; }
    public List<EmployeeDto> Employees {  get; set; } 
}