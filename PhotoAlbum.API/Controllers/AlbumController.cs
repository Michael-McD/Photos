using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoAlbum.api.Services;

namespace PhotoAlbum.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly ILogger<PhotoController> logger;
        private readonly PhotoAlbumService photoAlbumService;

        public AlbumController(ILogger<PhotoController> logger, PhotoAlbumService photoAlbumService)
        {
            this.logger = logger;
            this.photoAlbumService = photoAlbumService;
        }

        [HttpGet]
        public async Task<IEnumerable<AlbumViewModel>> GetAsync()
        {
            var photos = await photoAlbumService.GetAlbums();

            return new List<PhotoViewModel>() { new PhotoViewModel { AlbumTitle = "Foo", PhotoTitle = "Goo", ThumbnailUrl = "url", URL = "url" } };
        }

    }
}
