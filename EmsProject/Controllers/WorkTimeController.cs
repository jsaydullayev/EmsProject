using Ems.Common.Dtos;
using Ems.Common.Models.WorkTimeModels;
using Ems.Data.Entities;
using Ems.Service.ApiServices.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ems.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class WorkTimeController(IBaseInfoService<WorkTime> service) : BaseInfoController<WorkTime, WorkTimeDto, AddWorkTimeModel, UpdateWorkTimeModel, int>(service)
{
}
