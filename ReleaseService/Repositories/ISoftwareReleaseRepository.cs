namespace ReleaseService.Repositories;

public interface ISoftwareReleaseRepository
{
    Task<SoftwareRelease> GetSoftwareRelease(Guid releaseId);
    //IList<SoftwareRelease> GetAllSoftwareReleases();
    Task<SoftwareRelease> UpdateSoftwareRelease(SoftwareRelease newObject);
    Task DeleteSoftwareRelease(Guid id);
}
