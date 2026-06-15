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

        public Album? GetAlbumByID(int id)
        {
            return _albumRepository.GetAlbumByID(id);
        }
    }

    public interface IAlbumService
    {
        List<Album> GetAllAlbums();
        Album? GetAlbumByID(int id);
    }
}