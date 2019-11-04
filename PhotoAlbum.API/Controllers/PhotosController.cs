using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoAlbum.api.Services;

namespace PhotoAlbum.api.Controllers
{
    [ApiController]
    [Route("photos")]
    public class PhotoController : ControllerBase
    {
        private readonly ILogger<PhotoController> logger;
        private readonly PhotoAlbumService photoAlbumService;

        public PhotoController(ILogger<PhotoController> logger, PhotoAlbumService photoAlbumService)
        {
            this.logger = logger;
            this.photoAlbumService = photoAlbumService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<PhotoViewModel>> GetAsync()
        {
            var photos = await photoAlbumService.GetPhotos();

            return new List<PhotoViewModel>() { new PhotoViewModel { AlbumTitle = "Foo", PhotoTitle = "Goo", ThumbnailUrl = "url", URL = "url" } };
        }
    }
}
