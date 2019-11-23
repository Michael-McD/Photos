using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoAlbum.api.Services;


namespace PhotoAlbum.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumPhotosController : ControllerBase
    {
        private readonly IPhotoAlbumService photoAlbumService;

        public AlbumPhotosController(IPhotoAlbumService photoAlbumService)
        {
            this.photoAlbumService = photoAlbumService;
        }

        [HttpGet("{userId}/albums")]
        public async Task<ActionResult<IEnumerable<AlbumViewModel>>> GetAsync(int userId)
        {
            var albums = await photoAlbumService.GetAlbums();

            var albumViewModels = (from album in albums
                where album.UserId == userId
                select new AlbumViewModel
                {
                    AlbumId = album.Id,
                    AlbumTitle = album.Title
                }).ToList();

            if (albumViewModels == null)
            {
                return NotFound();
            }

            return Ok(albumViewModels);
        }

        [HttpGet("{userId}/albums/{albumId}")]
        public async Task<ActionResult<IEnumerable<PhotoViewModel>>> GetAsync(int userId, int albumId)
        {
            var albums = await photoAlbumService.GetAlbums();
            var photos = await photoAlbumService.GetPhotos();

            var photoViewModels =  from album in albums
                   where album.UserId == userId && album.Id == albumId
                   join photo in photos on album.Id equals photo.AlbumId
                   select new PhotoViewModel
                   {
                       PhotoId = photo.Id,
                       AlbumTitle = album.Title,
                       PhotoTitle = photo.Title,
                       URL = photo.Url,
                       ThumbnailUrl = photo.ThumbnailUrl
                   };

            return Ok(photoViewModels);
        }

        [HttpGet("{userId}/albums/{albumId}/photo/{photoId}")]
        public async Task<ActionResult<PhotoViewModel>> GetAsync(int userId, int albumId, int photoId)
        {
            var albums = await photoAlbumService.GetAlbums();
            var photos = await photoAlbumService.GetPhotos();

            var photo = (from album in albums
                   where album.UserId == userId && album.Id == albumId
                   join p in photos on album.Id equals p.AlbumId
                   where p.Id == photoId
                   select new PhotoViewModel
                   {
                       PhotoId = p.Id,
                       AlbumTitle = album.Title,
                       PhotoTitle = p.Title,
                       URL = p.Url,
                       ThumbnailUrl = p.ThumbnailUrl
                   }).FirstOrDefault();

            if (photo == null)
                return NotFound();

            return photo;
        }
    }
}
