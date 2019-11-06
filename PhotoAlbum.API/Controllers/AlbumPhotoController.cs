using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoAlbum.api.Services;


/*
/{user_id}/Albums/
{/{user_id}/Albums/{album_id}/photos
{/{user_id}/Albums/{album_id}/photos/{photo_id}
*/
namespace PhotoAlbum.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumPhotoController : ControllerBase
    {
        private readonly IPhotoAlbumService photoAlbumService;

        public AlbumPhotoController(IPhotoAlbumService photoAlbumService)
        {
            this.photoAlbumService = photoAlbumService;
        }

        [HttpGet("{userId}/albums")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<AlbumViewModel>> GetAsync(int userId)
        {
            var albums = await photoAlbumService.GetAlbums();

            return from album in albums
                   where album.UserId == userId
                   select new AlbumViewModel
                   {
                       AlbumId = album.Id,
                       AlbumTitle = album.Title
                   };
        }
    }
}
