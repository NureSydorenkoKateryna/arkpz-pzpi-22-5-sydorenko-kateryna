using FoodFlow.Common.Domain;

namespace FoodFlow.Modules.Movements.Core.Entities;

public class Warehouse : BaseEntity
{
    public string Name { get; set; }
    public string SpotId { get; set; }

    public ICollection<Import> Imports { get; set; }
    public ICollection<WriteOff> WriteOffs { get; set; }
    public ICollection<Rest> Rests { get; set; }
}
