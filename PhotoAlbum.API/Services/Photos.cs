using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhotoAlbum.api.Services
{    public class Photos
    {
        HttpClient _client { get; }

        public Photos(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<PhotoDomainModel>> GetPhotos()
        {
            var response = await _client.GetAsync("photos");

            return new List<PhotoDomainModel>();
        }
    }
}
