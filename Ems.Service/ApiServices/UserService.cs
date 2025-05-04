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
using System.Security.Claims;

namespace Ems.Service.ApiServices;
public class UserService : StatusGenericHandler, IUserService
{
    private readonly IUnitOfWork _userRepository;
    private readonly JwtService _jwtService;

    // Konstruktor orqali dependensiyalarni inject qilish
    public UserService(IUnitOfWork userRepository, JwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }
    public async Task<List<UserDto>> GetAllUsers()
    {
        var users = (await _userRepository.UserRepository().GetAll()).ToList();
        return users.MapToDtos<User, UserDto>();
    }

    public async Task<UserDto?> GetUserById(Guid id)
    {
        var user = await _userRepository.UserRepository().GetById(id);
        if (user is null)
        {
            AddError("User not found");
            return null;
        }
        return user.MapToDto<User, UserDto>();
    }

    public async Task<UserDto?> GetUserByUsername(string username)
    {
        var user = await (await _userRepository.UserRepository().GetAll()).Where(u => u.Username == username).FirstOrDefaultAsync();
        if (user is null)
        {
            return null;
        }
        return user.MapToDto<User, UserDto>();
    }

    public async Task<TokenDto?> Login(LoginModel model)
    {
        var userDto = await GetUserByUsername(model.Username);
        if(userDto is null)
        {
            AddError("User not found");
            return null;
        }

        var user = userDto!.MapToEntity<User, UserDto>();
        var isPasswordValid = ValidatePassword(user, model.Password);
        if (!isPasswordValid)
        {
            AddError("Invalid password");
            return null;
        }
        var token = _jwtService.GenerateToken(user, true);
        await _userRepository.UserRepository().SaveChanges();
        return token;
    }

    public async Task<UserDto?> Profile(ClaimsPrincipal user)
    {
        if (user is null)
        {
            AddError("User not found");
            return null;
        }

        var userClaims = user.FindFirst(ClaimTypes.NameIdentifier);
        if (userClaims is null)
        {
            AddError("Id not found");
            return null;
        }
        var userId = Guid.Parse(userClaims.Value!);
        var userdb = await _userRepository.UserRepository().GetById(userId);
        if (userdb is null)
        {
            AddError("User not found");
            return null;
        }

        return userdb.MapToDto<User, UserDto>();
    }

    public async Task<TokenDto?> RefreshToken(TokenDto model)
    {
        var (isValidAccessToken, username) = _jwtService.ValidateToken(model.AccessToken);

        if (!isValidAccessToken)
        {
            AddError("Invalid access token");
            return null;
        }
        var userFiles = await GetUserByUsername(username);
        var user = userFiles!.MapToEntity<User, UserDto>();
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

        var tokenDto = _jwtService.GenerateToken(user, false);
        return tokenDto;
    }

    public async Task Register(CreateUserModel model)
    {
        var userFiles = await GetUserByUsername(model.Username);
        if(userFiles is null)
        {
            AddError("User not found");
            return;
        }
        var user = userFiles!.MapToEntity<User, UserDto>();
        if (user is not null)
        {
            AddError("Username already taken");
            return;
        }

        var newUser = model.MapToEntity<User, CreateUserModel>();
        newUser.PasswordHash = new PasswordHasher<User>().HashPassword(newUser, model.Password);
        newUser.RoleId = 1;
        await _userRepository.UserRepository().Add(newUser);
        await _userRepository.UserRepository().SaveChanges();

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
