using StatusGeneric;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ems.Service.Extensions;
public static class ErrorExtencion
{
    public static void CopyToModelState(this IStatusGeneric status, ModelStateDictionary modelState)
    {
        if (!status.HasErrors)
        {
            return;
        }

        foreach (ErrorGeneric error in status.Errors)
        {
            var ll = error.ErrorResult.MemberNames.FirstOrDefault();
            modelState.AddModelError
                (
                    key: error.ErrorResult.MemberNames.Count() == 1 ? error.ErrorResult.MemberNames.First() : "",
                    error.ErrorResult.ToString()
                );
        }
    }
}
