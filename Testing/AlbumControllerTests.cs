using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Moq;
using Smoka.Controllers;
using Smoka.Services;
using Smoka.Models;

namespace Testing;

public class AlbumControllerTests
{
    private Mock<IAlbumService> _albumServiceMock;
    private List<Album> _albums;
    private List<Album> _emptyAlbums;
    private AlbumController _albumController;

    [SetUp]
    public void Setup()
    {
        _albumServiceMock = new Mock<IAlbumService>();
        _albumController = new AlbumController(_albumServiceMock!.Object);

        _albums = new List<Album>
        {
            new Album { Id = 1, Title = "Led Zeppelin", Genre = "Rock", ReleaseDate = 1971 },
            new Album { Id = 4, Title = "Siembra", Genre = "Salsa", ReleaseDate = 1978 }
        };

        _emptyAlbums = new List<Album>();

    }

    [Test]
    public void GetAllAlbums_ReturnsFullListOfAlbums()
    {
        _albumServiceMock.Setup(service => service.GetAllAlbums()).Returns(_albums);

        var result = _albumController.GetAllAlbums();

        Assert.That(result, Is.TypeOf<OkObjectResult>());

        var okResult = (OkObjectResult)result;

        Assert.That(okResult.Value, Is.EqualTo(_albums));
    }
}