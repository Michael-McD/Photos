using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PhotoAlbum.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotoController : ControllerBase
    {

        private readonly ILogger<PhotoController> _logger;

        public PhotoController(ILogger<PhotoController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public IEnumerable<PhotoViewModel> Get()
        {
            return new List<PhotoViewModel>() { new PhotoViewModel { AlbumTitle = "Foo", PhotoTitle = "Goo", ThumbnailUrl = "url", URL = "url" } };
        }
    }
}
