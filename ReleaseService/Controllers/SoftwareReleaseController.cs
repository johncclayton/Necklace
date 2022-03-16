namespace ReleaseService.Controllers;

[ApiController]
[Route("[controller]")]
public class SoftwareReleaseController : ControllerBase
{
    private readonly ILogger<SoftwareReleaseController> _logger;
    private DaprClient _daprClient;

    public SoftwareReleaseController(DaprClient daprClient, ILogger<SoftwareReleaseController> logger)
    {
        _daprClient = daprClient;
        _logger = logger;
    }

    [HttpGet(Name = "GetSoftwareRelease")]
    public IEnumerable<SoftwareRelease> Get()
    {
        return null;
        // TODO: fetch all the software releases from DAPR state/storage.
        //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //{
        //    Date = DateTime.Now.AddDays(index),
        //    TemperatureC = Random.Shared.Next(-20, 55),
        //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //})
        //.ToArray();
    }
}
