namespace EMS.Common.Models.UserModels;

public class CreateUserModel
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string FullName { get; set; }
    
    // The property will be made unique in OnModelCreating method configuration
    public string Username { get; set; }
    

    public string? PhoneNumber { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int RoleId { get; set; }
    public int GenderId { get; set; }
}