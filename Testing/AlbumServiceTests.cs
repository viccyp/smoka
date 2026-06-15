using Moq;
using Smoka.Models;
using Smoka.Repositories;
using Smoka.Services;

namespace Testing;

public class AlbumServiceTests
{
    private AlbumService _albumService;
    private Mock<IAlbumRepository> _albumRepositoryMock;

    [SetUp]
    public void Setup()
    {
        _albumRepositoryMock = new();
        _albumService = new AlbumService(_albumRepositoryMock.Object);
    }

    [Test]
    public void GetAllAlbums_ReturnsFullListWhenAlbumsExist()
    {
        var albums = new List<Album>
    {
        new Album { Id = 1, Title = "Led Zeppelin", Genre = "Rock", ReleaseDate = 1971 },
        new Album { Id = 4, Title = "Siembra", Genre = "Salsa", ReleaseDate = 1978 }
    };

        _albumRepositoryMock.Setup(repo => repo.GetAllAlbums()).Returns(albums);

        var result = _albumService.GetAllAlbums();

        Assert.That(result, Has.Count.EqualTo(2));
        Assert.That(result[0].Title, Is.EqualTo("Led Zeppelin"));
        Assert.That(result[1].Title, Is.EqualTo("Siembra"));
    }

    [Test]
    public void GetAllAlbums_ReturnsEmptyListWhenNoAlbumsExist()
    {
        var albums = new List<Album>();

        _albumRepositoryMock.Setup(repo => repo.GetAllAlbums()).Returns(albums);

        var result = _albumService.GetAllAlbums();

        Assert.That(result, Is.Empty);
        Assert.That(result, Has.Count.EqualTo(0));
    }

}
