using Ems.Common.Dtos;
using Ems.Common.Models.InfoDistrictModel;
using Ems.Data.Entities;
using Ems.Service.ApiServices.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ems.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DistrictController(IBaseInfoService<InfoDistrict> service) : BaseInfoController<InfoDistrict, InfoDistrictDto, CreateInfoDistrictModel, UpdateInfoDistrictModel, int>(service)
{
}
