using FoodFlow.Common.Result;

namespace FoodFlow.Common.Persistence;
public class RepositoryResult
{
    public static ResultData FailToAdd(string entityName) => new ResultData("FAILED_TO_ADD", $"Failed to add {entityName}");
    public static ResultData FailToUpdate(string entityName) => new ResultData("FAILED_TO_UPDATE", $"Failed to update {entityName}");
    public static ResultData FailToDelete(string entityName) => new ResultData("FAILED_TO_DELETE", $"Failed to delete {entityName}");
    public static ResultData FailToGet(string entityName) => new ResultData("FAILED_TO_GET", $"Failed to get {entityName}");
    public static ResultData FailToGetAll(string entityName) => new ResultData("FAILED_TO_GET_ALL", $"Failed to get all {entityName}");
    public static ResultData FailToGetById(string entityName) => new ResultData("FAILED_TO_GET_BY_ID", $"Failed to get {entityName} by id");
    public static ResultData FailToGetByFilter(string entityName) => new ResultData("FAILED_TO_GET_BY_FILTER", $"Failed to get {entityName} by filter");
    public static ResultData FailToGetFirstOrDefault(string entityName) => new ResultData("FAILED_TO_GET_FIRST_OR_DEFAULT", $"Failed to get first or default {entityName}");
    public static ResultData NotFound(string entityName) => new ResultData("NOT_FOUND", $"{entityName} not found");
    public static ResultData FailToCheckUniqueness(string entityName) => new ResultData("FAILED_TO_CHECK_UNIQUENESS", $"Failed to check uniqueness of {entityName}");

}
