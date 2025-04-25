using Ems.Common.Models.BaseModels;
namespace Ems.Common.Models.WorkTimeModels;
public class UpdateWorkTimeModel : UpdateRegionBaseModel
{
    public string Details { get; set; }
    public int PerWeekAmount { get; set; }
}
