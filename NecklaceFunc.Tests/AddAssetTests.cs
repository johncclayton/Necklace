using Xunit;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

using Necklace;

namespace NecklaceFunc.Tests;

public class AddAssetTests
{
    private readonly ILogger logger = TestFactory.CreateLogger();

    [Fact]
    public async void Test_that_an_asset_can_be_added()
    {
        var request = TestFactory.CreateHttpRequest("name", "Bill");
        var container = TestFactory.GetBlobContainerClient();
        var response = await ListAssets.Run(request, container, logger);
        System.Console.WriteLine(response);
    }
}