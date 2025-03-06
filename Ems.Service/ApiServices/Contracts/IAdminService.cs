using Microsoft.AspNetCore.Http;

namespace Ems.Service.ApiServices.Contracts;
public interface IAdminService
{
    Task AddContent(IFormFile file);
}
