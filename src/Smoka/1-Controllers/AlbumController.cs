using Smoka.Services;

namespace Smoka.Controllers
{
    public class AlbumController(IAlbumService albumService) : IAlbumController
    {
        private readonly IAlbumService _albumService = albumService;
    }

    public interface IAlbumController;
}