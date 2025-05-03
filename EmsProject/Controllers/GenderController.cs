using Ems.Common.Dtos;
using Ems.Common.Models.GenderModels;
using Ems.Data.Entities;
using Ems.Service.ApiServices.Contracts;
using Microsoft.AspNetCore.Mvc;
namespace Ems.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class GenderController(IBaseInfoService<Gender> service) : BaseInfoController<Gender, GenderDto, CreateGenderModel, UpdateGenderModel, int>(service)
{
}
