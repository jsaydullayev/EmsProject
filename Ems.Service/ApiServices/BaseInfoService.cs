using Ems.Service.ApiServices.Contracts;
using Ems.Service.Extensions;
using Ems.Data.Repositories.Contracts;
using StatusGeneric;

namespace Ems.Service.ApiServices;
public class BaseInfoService<TEntity>(IBaseRepository<TEntity> baseRepository) : StatusGenericHandler, IBaseInfoService<TEntity>
    where TEntity : class
{
    public async Task<string> Create<TModel>(TModel model)
    {
        var entity = model.MapToEntity<TEntity, TModel>();
        await baseRepository.Add(entity);

        await baseRepository.SaveChanges();
        return "Added succesfully";
    }

    public async Task<string?> DeleteById<TK>(TK id)
    {
        var (check, entity) = await GetEntityIfExist(id);
        if (!check)
        {
            return null;
        }
        await baseRepository.Delete(entity);
        await baseRepository.SaveChanges();
        return "Deleted successfully";
    }

    public async Task<List<TDto>> GetAll<TDto>()
    {
        var entities = (await baseRepository.GetAll()).ToList();
        return entities.MapToDtos<TEntity, TDto>();
    }

    public async Task<TDto?> GetById<TDto, TK>(TK id)
    {
        var (check, entity) = await GetEntityIfExist(id);
        if (!check)
            return default;

        return entity!.MapToDto<TEntity, TDto>();
    }

    public async Task<string?> Update<TK, TModel>(TK id, TModel model)
    {
        var (check, entity) = await GetEntityIfExist(id);
        if (!check)
        {
            return null;
        }

        var entityProperties = typeof(TEntity).GetProperties();
        var modelProperties = model?.GetType().GetProperties();
    
        if(modelProperties is not null)
        {
            foreach(var modelProperty in modelProperties)
            {
                var entityProperty = entityProperties.FirstOrDefault(x => x.Name == modelProperty.Name);
                if(entityProperty is not null)
                {
                    var updateValue = modelProperty.GetValue(obj: model);
                    if(updateValue is not null)
                    {
                        entityProperty.SetValue(obj: entity, value: updateValue);
                    }
                }
            }
            await baseRepository.Update(entity!);
            await baseRepository.SaveChanges();
        }
        return "Updated successfully";
    }

    private async Task<Tuple<bool, TEntity?>> GetEntityIfExist<TId>(TId id)
    {
        var entity = await baseRepository.GetById(id);
        if(entity is null)
        {
            AddError("Entity not found");
            return new(false, null);
        }
        return new(true, entity);
    }
}
