namespace ReleaseService.Repositories;

public interface ISoftwareReleaseRepository
{
    SoftwareRelease GetSoftwareRelease(string releaseId);
    IList<SoftwareRelease> GetAllSoftwareReleases();
}
