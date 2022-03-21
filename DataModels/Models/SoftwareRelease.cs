namespace DataModels.Models;

public record SoftwareRelease(
    Guid Id,
    string ProductName,
    string Description,
    string Channel,
    DateTime Created
    );
