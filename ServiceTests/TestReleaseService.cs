using System.Net.Http;
using Dapr.Client;
using Xunit;

namespace ServiceTests
{
    public class TestReleaseService
    {
        [Fact]
        public async void TestCanFetchSingleRelease()
        {
            // fire up Dapr and pull a single record from the ReleaseService
            var client = new DaprClientBuilder().
                UseHttpEndpoint("http://localhost:7001")
                .UseGrpcEndpoint("http://localhost:8001").Build();
   
            var result = client.CreateInvokeMethodRequest(HttpMethod.Get, 
                "releaseservice", "softwarerelease/" + 12);
            
            await client.InvokeMethodAsync(result);
        }
    }
}