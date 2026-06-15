using Smoka.Services;
using Microsoft.AspNetCore.Mvc;
using Smoka.Models;

namespace Smoka.Controllers
{
    [ApiController]

    public class AlbumController(IAlbumService albumService) : ControllerBase
    {
        private readonly IAlbumService _albumService = albumService;

        [HttpGet]
        public IActionResult GetAllAlbums()
        {
            var albums = _albumService.GetAllAlbums();
                return Ok(albums);
        }

        [HttpGet]
        public IActionResult GetAlbumByID(int id)
        {
            var album = _albumService.GetAlbumByID(id);

            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }
    }
}