using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhotoAlbum.api.Services
{
    public class PhotoAlbumService : IPhotoAlbumService
    {
        private HttpClient client { get; }

        public PhotoAlbumService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<PhotoDomainModel>> GetPhotos()
        {
            var response = await client.GetAsync("photos");

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<PhotoDomainModel>>(json);
            }
            else
            {
                var errorCode = Enum.GetName(typeof(HttpStatusCode), response.StatusCode);
                throw new HttpRequestException(errorCode);
            }
        }

        public async Task<IEnumerable<AlbumDomainModel>> GetAlbums()
        {
            var response = await client.GetAsync("albums");

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<AlbumDomainModel>>(json);
            }
            else
            {
                var errorCode = Enum.GetName(typeof(HttpStatusCode), response.StatusCode);
                throw new HttpRequestException(errorCode);
            }
        }
    }
}
