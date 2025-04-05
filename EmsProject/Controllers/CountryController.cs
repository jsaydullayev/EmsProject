using Ems.Common.Dtos;
using Ems.Common.Models.InfoCountryModel;
using Ems.Data.Entities;
using Ems.Service.ApiServices.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ems.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CountryController(IBaseInfoService<InfoCountry> service) : BaseInfoController<InfoCountry, InfoCountryDto, CreateInfoCountryModel, UpdateInfoCountryModel, int>(service)
{

}
