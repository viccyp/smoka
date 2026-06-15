using Smoka.Models;
using System.Text.Json;

namespace Smoka.Repositories
{
    public interface IAlbumRepository
    {
        List<Album> GetAllAlbums();
    }
    public class AlbumRepository : IAlbumRepository
    {
        private readonly string _pathToAlbums = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "albums.json");

        public List<Album> GetAllAlbums()
        {
            var jsonAlbums = File.ReadAllText(_pathToAlbums);
            return JsonSerializer.Deserialize<List<Album>>(jsonAlbums) ?? new List<Album>();
        }
    }



}