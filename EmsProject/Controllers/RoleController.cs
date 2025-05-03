using Ems.Common.Dtos;
using Ems.Common.Models.BaseModels;
using Ems.Common.Models.RoleModels;
using Ems.Data.Entities;
using Ems.Service.ApiServices.Contracts;
using Microsoft.AspNetCore.Mvc;
namespace Ems.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class RoleController(IBaseInfoService<Role> service) : BaseInfoController<Role, RoleDto, CreateRoleModel, UpdateRegionBaseModel, int>(service)
{
}
