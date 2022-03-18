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

    [HttpGet("{id}")]
    public IEnumerable<SoftwareRelease> Get(string id)
    {
        return Enumerable.Range(1, 1).Select(index => new SoftwareRelease
        (
            Id: index.ToString(),
            ProductName: "Product with a name",
            Description: "this is a description",
            created: DateTime.Now
        )).ToArray();
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
