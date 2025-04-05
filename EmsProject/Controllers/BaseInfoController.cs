using Ems.Service.ApiServices.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Ems.Api.Controllers;

[ApiController]
public class BaseInfoController<TEntity, TDto, TCreateModel, TUpdate, TId>(IBaseInfoService<TEntity> service) : ControllerBase
    where TEntity : class
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await service.GetAll<TDto>();
        if(service.IsValid)
            return Ok(result);

        return BadRequest(service.Errors);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(TId id)
    {
        var result = await service.GetById<TDto, TId>(id);
        if (service.IsValid)
            return Ok(result);

        return BadRequest(service.Errors);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TCreateModel model)
    {
        var result = await service.Create<TCreateModel>(model);
        if (service.IsValid)
            return Ok(result);

        return BadRequest(service.Errors);
    }

    [HttpPut]
    public async Task<IActionResult> Update(TId id,TUpdate model)
    {
        var result = await service.Update<TId,TUpdate>(id,model);
        if (service.IsValid)
            return Ok(result);

        return BadRequest(service.Errors);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(TId id)
    {
        var result = await service.DeleteById<TId>(id);
        if(service.IsValid)
        return Ok(result);

        return BadRequest(service.Errors);
    }

}
