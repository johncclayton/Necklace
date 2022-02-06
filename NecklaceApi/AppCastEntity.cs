using Azure;
using Azure.Data.Tables;

namespace NecklaceApi;

public class AppCastEntity : ITableEntity
{
    public DateTime CreatedTime { get; set; }
    public string? Description { get; set; }
    public bool ProductName { get; set; }
    
    public string PartitionKey { get => "APPCAST"; set => _ = value; }
    public string RowKey { get; set; }
    
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
}