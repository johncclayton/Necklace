namespace ReleaseService.Repositories;

public interface ISoftwareReleaseRepository
{
    SoftwareRelease GetSoftwareRelease(Guid releaseId);
    //IList<SoftwareRelease> GetAllSoftwareReleases();
}
