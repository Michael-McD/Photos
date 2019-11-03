using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhotoAlbum.api.Services
{ public class PhotosService
    {
        HttpClient _client { get; }

        public PhotosService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<PhotoDomainModel>> GetPhotos()
        {
            var response = await _client.GetAsync("photos");

            if (response.IsSuccessStatusCode)
            {
                var photosJSON = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<PhotoDomainModel>>(photosJSON);
            }
            else
            {
                var errorCode = Enum.GetName(typeof(HttpStatusCode), response.StatusCode);
                throw new HttpRequestException(errorCode);
            }
        }
    }
}
