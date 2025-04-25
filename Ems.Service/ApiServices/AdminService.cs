using Ems.Common.Models.BaseModels;
using Ems.Common.Models.ContentModels;
using Ems.Data.Entities;
using Ems.Data.Repositories.Contracts;
using Ems.Service.ApiServices.Contracts;
using Ems.Service.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Ems.Service.ApiServices;
public class AdminService : IAdminService
{
    private readonly IUnitOfWork _Repository;

    public AdminService(IUnitOfWork Repository)
    {
        _Repository = Repository;
    }

    public async Task AddContent(IFormFile file)
    {
        await using var transaction = _Repository.InfoContentTypeRepository().BeginTransaction();
        {
            try
            {
                var type = file.ContentType;

                var contentType = await (await _Repository.InfoContentTypeRepository()
                    .GetAll()).Where(c => c.FullName == type).FirstOrDefaultAsync();

                if (contentType is null)
                {
                    var model = new CreateBaseInfoModel()
                    {
                        Code = type[0].ToString(),
                        ShortName = type[0].ToString(),
                        FullName = type,
                        TypeName = type
                    };

                    contentType = model.MapToEntity<InfoContentType, CreateBaseInfoModel>();
                    await _Repository.InfoContentTypeRepository().Add(contentType);
                    await _Repository.InfoContentTypeRepository().SaveChanges();
                }

                var ms = new MemoryStream();
                await file.CopyToAsync(ms);

                var fileUrl = Guid.NewGuid().ToString();

                await File.WriteAllBytesAsync(fileUrl, ms.ToArray());

                var contentModel = new CreateContentModel()
                {
                    Name = file.Name,
                    FileUrl = fileUrl,
                    ContentTypeId = contentType.Id,
                };

                var infoContent = contentModel.MapToEntity<InfoContent, CreateContentModel>();

                await _Repository.InfoContentRepository().Add(infoContent);
                await _Repository.InfoContentRepository().SaveChanges();

                Console.WriteLine("Successfully added content");

                await transaction.CommitAsync();

            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                throw new Exception(e.Message);
            }
        }
    }
}
