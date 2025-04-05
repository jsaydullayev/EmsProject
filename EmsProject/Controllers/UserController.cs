using Ems.Common.Models.UserModels;
using Ems.Service.ApiServices;
using Ems.Service.Extensions;
using Microsoft.AspNetCore.Mvc;
using StatusGeneric;

namespace Ems.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserController(UserService userService) : ControllerBase
{
    private readonly UserService _userService = userService;


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
        if(tokenDto is )
    }
}
