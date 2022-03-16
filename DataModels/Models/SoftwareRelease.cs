namespace DataModels.Models;

public record class SoftwareRelease(
    string Id,
    string ProductName,
    string Description,
    DateTime created
    );
