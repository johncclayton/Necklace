using Xunit;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

using Necklace;
using Xunit.Abstractions;

namespace NecklaceFunc.Tests;

public class AddAssetTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ILogger logger = TestFactory.CreateLogger();

    public AddAssetTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async void Test_that_an_asset_can_be_added()
    {
        var request = TestFactory.CreateHttpRequest("name", "Bill");
        var container = TestFactory.GetBlobContainerClient();
        var response = await ListAssets.Run(request, container, logger);
        _testOutputHelper.WriteLine(response.ToString());
    }
}