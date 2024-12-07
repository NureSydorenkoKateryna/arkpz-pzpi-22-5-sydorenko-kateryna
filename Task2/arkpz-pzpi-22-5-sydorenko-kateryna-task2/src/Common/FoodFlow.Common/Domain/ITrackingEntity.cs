namespace FoodFlow.Common.Domain;

public interface ITrackingEntity
{
    DateTime CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
}
