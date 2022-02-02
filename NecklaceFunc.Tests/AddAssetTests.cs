using Xunit;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace NecklaceFunc.Tests;

public class AddAssetTests
{
    private readonly ILogger logger = TestFactory.CreateLogger();

    [Fact]
    public async void Test_that_an_asset_can_be_added()
    {

    }
}