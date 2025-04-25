using System.ComponentModel.DataAnnotations;

namespace Ems.Common.Models.UserModels;

public class CreateUserModel
{
    [Required]
    [StringLength(30)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(30)]
    public string LastName { get; set; }

    [Required]
    [StringLength(30)]
    public string FullName { get; set; }

    [Required]
    [StringLength(30)]
    public string Username { get; set; }
    
    [Phone]
    public string? PhoneNumber { get; set; }

    [DataType("dd.mm.yyyy")]
    public DateTime? DateOfBirth { get; set; }
    public int GenderId { get; set; }
    
    public required string Password { get; set; }
    [Compare(nameof(Password))]
    public required string ConfirmPassword { get; set; }
}