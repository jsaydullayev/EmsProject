using System.ComponentModel.DataAnnotations;

namespace Ems.Common.Models.UserModels;

public class LoginModel
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    [Compare(nameof(Password))]
    public required string ConfirmPassword { get; set; }
}