using Azure.Data.Tables;
namespace Necklace.Api;

public class AppCast 
{
    public DateTime CreatedTime { get; set; }
    public string Description { get; set; }
    public bool ProductName { get; set; }
}

public class AppCastEntity : TableEntity
{
    public DateTime CreatedTime { get; set; }
    public string Description { get; set; }
    public bool ProductName { get; set; }
}

public static class Mappings
{
    public static AppCastEntity ToTableEntity(this AppCast cast)
    {
        return new AppCastEntity
        {
            PartitionKey = "APPCAST",
            RowKey = cast.Id,
            Description = cast.Description,
            ProductName = cast.ProductName,
        };
    }

    public static AppCast FromTableEntity(this AppCastEntity cast)
    {
        return new AppCast
        {
            Id = cast.RowKey,
            CreatedTime = cast.CreatedTime,
            Description = cast.Description,
            ProductName = cast.ProductName
        };
    }
}
