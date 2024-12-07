using FoodFlow.Common.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodFlow.Modules.Movements.Core.Entities;

public class Movement : BaseEntity, ITrackingEntity
{
    public string ProductId { get; set; }
    public decimal Quantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

}
