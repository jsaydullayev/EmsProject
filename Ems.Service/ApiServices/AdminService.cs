using Ems.Data.Entities;
using Ems.Data.Repositories.Contracts;
using Ems.Service.ApiServices.Contracts;
using Ems.Service.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Ems.Service.ApiServices;
public class AdminService : IAdminService
{
    private readonly IBaseRepository<InfoContentType> _contentTypeRepository;
    private readonly IBaseRepository<InfoContent> _infoContentRepository;

    public AdminService(IBaseRepository<InfoContentType> contentTypeRepository, IBaseRepository<InfoContent> infoContentRepository)
    {
        _contentTypeRepository = contentTypeRepository;
        _infoContentRepository = infoContentRepository;
    }

    public async Task AddContent(IFormFile file)
    {
        await using var transaction = _contentTypeRepository.BeginTransaction();
        {
            try
            {
                var type = file.ContentType;

                var contentType = await (await _contentTypeRepository
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
                    await _contentTypeRepository.Add(contentType);
                    await _contentTypeRepository.SaveChanges();
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

                await _infoContentRepository.Add(infoContent);
                await _infoContentRepository.SaveChanges();

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
