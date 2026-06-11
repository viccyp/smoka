using Smoka.Repositories;

namespace Smoka.Services
{
    public class AlbumService(IAlbumRepository albumRepository) : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository = albumRepository;
    }

    public interface IAlbumService;
}