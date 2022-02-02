using Xunit;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Necklace;

namespace NecklaceFunc.Tests;

public class AddAssetTests
{
    private readonly ILogger logger = TestFactory.CreateLogger();

    [Fact]
    public async void Test_that_an_asset_can_be_added()
    {
        var request = TestFactory.CreateHttpRequest("name", "Bill");
        var response = await ListAssets.Run(request, logger);
        System.Console.WriteLine(response);
    }
}