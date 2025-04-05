using Ems.Service.ApiServices.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ems.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AdminController(IAdminService adminService) : Controller
{
    private readonly IAdminService _adminService = adminService;

    [HttpPost]
    public async Task<IActionResult> AddContent(IFormFile formFile)
    {
        await _adminService.AddContent(formFile);
        return File(new MemoryStream(), "image/png");
    }
}
