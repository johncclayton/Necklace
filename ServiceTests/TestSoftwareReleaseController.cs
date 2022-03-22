using System;
using System.Threading.Tasks;
using DataModels.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ReleaseService.Controllers;
using ReleaseService.Repositories;
using Xunit;

namespace ServiceTests;

public class TestSoftwareReleaseController
{
    private readonly Guid _newGuid;
    private readonly SoftwareReleaseController _controller;

    public TestSoftwareReleaseController()
    {
        var mockRepo = new Mock<ISoftwareReleaseRepository>();
        _newGuid = Guid.NewGuid();
        mockRepo.Setup(repo 
            => repo.GetSoftwareRelease(_newGuid)).ReturnsAsync(GetSingleRecord());
        mockRepo.Setup(repo
            => repo.UpdateSoftwareRelease(It.IsAny<SoftwareRelease>())).ReturnsAsync((SoftwareRelease r) => r);
        _controller = new SoftwareReleaseController(mockRepo.Object);
    }

    private SoftwareRelease GetSingleRecord()
    {
        return new SoftwareRelease(
            Id: _newGuid,
            ProductName: "MyProduct",
            Channel: "stable",
            Created: DateTime.Now,
            Description: "it's an object!"
        );
    }

    [Fact]
    public async Task TestCanUpdateWithNoGuid()
    {
        SoftwareRelease data = GetSingleRecord() with { Id = Guid.Empty };
        var result = await _controller.Update(Guid.Empty, data);
        Assert.NotNull(result);
        SoftwareRelease resp = Assert.IsType<SoftwareRelease>(result);
        
    }

    [Fact]
    public async Task TestCanFetch()
    {
        var result = await _controller.Get(_newGuid);
        
        Assert.NotNull(result);
        SoftwareRelease obj = Assert.IsAssignableFrom<SoftwareRelease>(result);
        Assert.Equal(_newGuid, obj.Id);
        Assert.Equal("MyProduct", obj.ProductName);
        Assert.Equal("it's an object!", obj.Description);
    }
    
    
}