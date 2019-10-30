using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Photos.api.Controllers
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
        public IEnumerable<Photo> Get()
        {
            return new List<Photo>() { new Photo {Id=1, AlbumId=1, Title="foo", Url= "https://foo.com", ThumbnailUrl="https://foo.com" } }; 
        }
    }
}
