using StatusGeneric;
using System.Web.Mvc;

namespace Ems.Service.ApiServices.Contracts;
public interface IBaseInfoService<TEntity> : IStatusGeneric
{
    Task<List<TDto>> GetAll<TDto>();
    Task<TDto?> GetById<TDto, TK>(TK id);
    Task<string> Create<TModel>(TModel model);
    Task<string?> Update<TK,TModel>(TK id,TModel model);
    Task<string?> DeleteById<TK>(TK id);
}
