using Ems.Common.Dtos;
using Ems.Common.Models.UserModels;
using Ems.Data.Entities;
using Ems.Data.Repositories.Contracts;
using Ems.Service.ApiServices.Contracts;
using Ems.Service.Extensions;
using Ems.Service.JWT;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StatusGeneric;

namespace Ems.Service.ApiServices;
public class UserService(IBaseRepository<User> userRepository, JwtService jwtService) : StatusGenericHandler, IUserService
{
    private readonly IBaseRepository<User> _userRepository = userRepository;

    public async Task<List<UserDto>> GetAllUsers()
    {
        var users = (await _userRepository.GetAll()).ToList();
        return users.MapToDtos<User, UserDto>();
    }

    public async Task<UserDto?> GetUserById(Guid id)
    {
        var user = await _userRepository.GetById(id);
        if (user is null)
        {
            AddError("User not found");
            return null;
        }
        return user.MapToDto<User, UserDto>();
    }

    public async Task<UserDto?> GetUserByUsername(string username)
    {
        var user = await (await _userRepository.GetAll()).Where(u => u.Username == username).FirstOrDefaultAsync();
        if (user is null)
        {
            AddError("User not found");
            return null;
        }
        return user.MapToDto<User, UserDto>();
    }

    public async Task<TokenDto?> Login(LoginModel model)
    {
        var userDto = await GetUserByUsername(model.Username);
        var user = userDto!.MapToEntity<User, UserDto>();
        if (user is null)
        {
            AddError("User not found");
            return null;
        }
        var isPasswordValid = ValidatePassword(user, model.Password);
        if (!isPasswordValid)
        {
            AddError("Invalid password");
            return null;
        }
        var token = jwtService.GenerateToken(user, true);
        await _userRepository.SaveChanges();
        return token;
    }

    public async Task<TokenDto?> RefreshToken(TokenDto model)
    {
        var (isValidAccessToken, username) = jwtService.ValidateToken(model.AccessToken);

        if (!isValidAccessToken)
        {
            AddError("Invalid access token");
            return null;
        }
        var userDto = await GetUserByUsername(username);
        var user = userDto!.MapToEntity<User, UserDto>();
        if (user is null)
        {
            AddError("User not found");
            return null;
        }

        var isValidRefreshToken = user.RefreshToken == model.RefreshToken;
        if (!isValidRefreshToken)
        {
            AddError("Invalid refresh token");
            return null;
        }

        var tokenDto = jwtService.GenerateToken(user, false);
        return tokenDto;
    }

    public async Task Register(CreateUserModel model)
    {
        var userDto = await GetUserByUsername(model.Username);
        var user = userDto!.MapToEntity<User, UserDto>();
        if (user is null)
        {
            AddError("Username already taken");
            return;
        }

        var newUser = model.MapToEntity<User, CreateUserModel>();
        newUser.PasswordHash = new PasswordHasher<User>().HashPassword(newUser, model.Password);
        await _userRepository.Add(newUser);
        await _userRepository.SaveChanges();

    }

    private bool ValidatePassword(User user, string password)
    {
        var isValid = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, password);
        if (isValid == PasswordVerificationResult.Failed)
        {
            AddError("Invalid password");
            return false;
        }
        return true;
    }
}
