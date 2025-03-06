using StatusGeneric;
using System.Web.Mvc;

namespace Ems.Service.Extensions;
public static class ErrorExtencion
{
    public static void CopyToModelState(this IStatusGeneric status, ModelStateDictionary model)
    {
        if (!status.HasErrors)
            return;
        
        foreach(ErrorGeneric error in status.Errors)
        {
            var l = error.ErrorResult.MemberNames.FirstOrDefault();
            model.AddModelError
                (
                key: error.ErrorResult.MemberNames.Count() == 1 ? error.ErrorResult.MemberNames.First() : "",
                error.ToString()
                );
        }
    }
}
