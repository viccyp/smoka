using Smoka.Models;
using Smoka.Repositories;

namespace Smoka.Services
{
    public class AlbumService(IAlbumRepository albumRepository) : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository = albumRepository;

        public List<Album> GetAllAlbums()
        {
            return _albumRepository.GetAllAlbums();
        }
    }

    public interface IAlbumService
    {
        List<Album> GetAllAlbums();
    }
}