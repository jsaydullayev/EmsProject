using Ems.Common.Models.UserModels;
using Ems.Service.ApiServices;
using Ems.Service.ApiServices.Contracts;
using Ems.Service.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ems.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;


    [HttpPost]
    public async Task<IActionResult> Register(CreateUserModel model)
    {
        await _userService.Register(model);
        if (_userService.IsValid)
        {
            return Ok("Done");
        }
        _userService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        var tokenDto = await _userService.Login(model);
        if (_userService.IsValid)
        {
            return Ok(tokenDto);
        }
        _userService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }

    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        var user = await _userService.Profile(User);

        if (_userService.IsValid)
        {
            return Ok(user);
        }

        // Agar xatoliklar bo'lsa, ModelState'ga qo'shish
        _userService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }
}
