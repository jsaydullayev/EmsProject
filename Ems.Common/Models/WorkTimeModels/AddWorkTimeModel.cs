using Ems.Common.Models.BaseModels;

namespace Ems.Common.Models.WorkTimeModels;
public class AddWorkTimeModel : CreateRegionBaseModel
{
    public string Details { get; set; }
    public int PerWeekAmount { get; set; }
    public int JobTypeId { get; set; }
    public int JobLevelId { get; set; }
}
