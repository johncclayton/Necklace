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

    public async Task<SoftwareRelease> GetSoftwareRelease(Guid releaseId)
    {
        return await _daprClient.GetStateAsync<SoftwareRelease>(DAPR_STORE_NAME, releaseId.ToString());
    }

    public async Task<SoftwareRelease> UpdateSoftwareRelease(SoftwareRelease newObject)
    {
        var storeObject = newObject;
        if(storeObject.Id == Guid.Empty)
            storeObject = newObject with { Id = Guid.NewGuid() };
        await _daprClient.SaveStateAsync(DAPR_STORE_NAME, storeObject.Id.ToString(), storeObject);
        return await Task.FromResult(storeObject);
    }

    public async Task DeleteSoftwareRelease(Guid id)
    {
        await _daprClient.DeleteStateAsync(DAPR_STORE_NAME, id.ToString());
    }
}
