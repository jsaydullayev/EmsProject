using Ems.Common.Dtos;
using Ems.Common.Models.UserModels;
using StatusGeneric;
namespace Ems.Service.ApiServices.Contracts;
public interface IUserService : IStatusGeneric
{
    Task<List<UserDto>> GetAllUsers();
    Task<UserDto?> GetUserById(Guid id);
    Task<UserDto?> GetUserByUsername(string username);
    Task Register(CreateUserModel model);
    Task<TokenDto?> Login(LoginModel model);
    Task<TokenDto?> RefreshToken(TokenDto model);
}
