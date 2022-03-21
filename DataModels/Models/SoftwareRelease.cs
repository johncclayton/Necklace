namespace DataModels.Models;

public record SoftwareRelease(
    Guid Id,
    string ProductName,
    string Description,
    DateTime Created
    );
