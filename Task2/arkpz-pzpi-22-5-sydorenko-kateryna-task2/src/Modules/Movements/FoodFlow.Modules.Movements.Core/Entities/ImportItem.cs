using FoodFlow.Common.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodFlow.Modules.Movements.Core.Entities;

public class ImportItem : Movement
{
    public decimal TotalPrice { get; set; }

    [NotMapped]
    public decimal PricePerUnit => TotalPrice != 0.0M ? Quantity / TotalPrice : 0.0M;

    public long ImportId { get; set; }
    public Import Import { get; set; }
}
