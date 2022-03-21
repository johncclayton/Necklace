namespace ReleaseService.Repositories;
using DataModels.Models;

public class DaprSoftwareRepository : ISoftwareReleaseRepository
{
    // ReSharper disable once InconsistentNaming
    private const string DAPR_STORE_NAME = "statestore";
    private readonly DaprClient _daprClient;

    public DaprSoftwareRepository(DaprClient client)
    {
        _daprClient = client;
    }

    // public IList<SoftwareRelease> GetAllSoftwareReleases()
    // {
    //     throw new NotImplementedException();
    // }

    public SoftwareRelease GetSoftwareRelease(Guid releaseId)
    {
        return _daprClient.GetStateAsync<SoftwareRelease>(DAPR_STORE_NAME, releaseId.ToString()).Result;
    }
}
