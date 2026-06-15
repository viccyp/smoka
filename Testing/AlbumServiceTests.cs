using Moq;
using Smoka.Models;
using Smoka.Repositories;
using Smoka.Services;

namespace Testing;

public class AlbumServiceTests
{
    private AlbumService _albumService;
    private Mock<IAlbumRepository> _albumRepositoryMock;
    private List<Album> _albums;
    private List<Album> _emptyAlbums;

    [SetUp]
    public void Setup()
    {
        _albumRepositoryMock = new();
        _albumService = new AlbumService(_albumRepositoryMock.Object);

        _albums = new List<Album>
        {
            new Album { Id = 1, Title = "Led Zeppelin", Genre = "Rock", ReleaseDate = 1971 },
            new Album { Id = 4, Title = "Siembra", Genre = "Salsa", ReleaseDate = 1978 }
        };

        _emptyAlbums = new List<Album>();
    }

    [Test]
    public void GetAllAlbums_ReturnsFullListWhenAlbumsExist()
    {

        _albumRepositoryMock.Setup(repo => repo.GetAllAlbums()).Returns(_albums);

        var result = _albumService.GetAllAlbums();

        Assert.That(result, Has.Count.EqualTo(2));
        Assert.That(result[0].Title, Is.EqualTo("Led Zeppelin"));
        Assert.That(result[1].Title, Is.EqualTo("Siembra"));
    }

    [Test]
    public void GetAllAlbums_ReturnsEmptyListWhenNoAlbumsExist()
    {
        _albumRepositoryMock.Setup(repo => repo.GetAllAlbums()).Returns(_emptyAlbums);

        var result = _albumService.GetAllAlbums();

        Assert.That(result, Is.Empty);
        Assert.That(result, Has.Count.EqualTo(0));
    }

    [Test]

    public void GetAlbumByID_ReturnsAlbumWithSpecificID()
    {
        _albumRepositoryMock.Setup(repo => repo.GetAlbumByID(1)).Returns(_albums[0]);

        var result = _albumService.GetAlbumByID(1);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(1));
        Assert.That(result.Title, Is.EqualTo("Led Zeppelin"));
    }
    
    [Test]

    public void GetAlbumByID_ReturnsNull_WhenAlbumIDDoesNotExist()
    {
        _albumRepositoryMock.Setup(repo => repo.GetAlbumByID(1)).Returns((Album?)null);

        var result = _albumService.GetAlbumByID(1);

        Assert.That(result, Is.Null);
        _albumRepositoryMock.Verify(repo => repo.GetAlbumByID(1),Times.Once);
    }


}
