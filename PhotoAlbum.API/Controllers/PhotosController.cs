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
        private readonly PhotosService photosService;

        public PhotoController(ILogger<PhotoController> logger, PhotosService photosService)
        {
            this.logger = logger;
            this.photosService = photosService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<PhotoViewModel>> GetAsync()
        {
            var foo = await photosService.GetPhotos();

            return new List<PhotoViewModel>() { new PhotoViewModel { AlbumTitle = "Foo", PhotoTitle = "Goo", ThumbnailUrl = "url", URL = "url" } };
        }
    }
}
