namespace ReleaseService.Repositories;

public class DaprSoftwareRepository : ISoftwareReleaseRepository
{
    private const string DAPR_STORE_NAME = "softwarerelease";
    private DaprClient _daprClient;

    public DaprSoftwareRepository(DaprClient client)
    {
        _daprClient = client;
    }

    public IList<SoftwareRelease> GetAllSoftwareReleases()
    {
        //return await _daprClient.GetBulkStateAsync<SoftwareRelease>(DAPR_STORE_NAME, )
        return null;
    }

    public SoftwareRelease GetSoftwareRelease(string releaseId)
    {
        return null;
    }
}
