using Ems.Common.Dtos;
using Ems.Common.Models.InfoCityModel;
using Ems.Data.Entities;
using Ems.Service.ApiServices;
using Ems.Service.ApiServices.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ems.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CityController(IBaseInfoService<InfoCity> service) : BaseInfoController<InfoCity, InfoCityDto, CreateInfoCityModel, UpdateInfoCityModel, int>(service)
{
}