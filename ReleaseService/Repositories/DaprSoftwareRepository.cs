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

    public async Task<SoftwareRelease> UpdateSoftwareRelease(SoftwareRelease newObject)
    {
        var storeObject = newObject with { Id = Guid.NewGuid() };
        await _daprClient.SaveStateAsync(DAPR_STORE_NAME, storeObject.Id.ToString(), storeObject);
        return await Task.FromResult(storeObject);
    }
}
