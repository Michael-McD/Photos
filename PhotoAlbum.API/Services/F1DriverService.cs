using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhotoAlbum.API.Models;

namespace PhotoAlbum.api.Services
{
    public class F1DriverService : IF1DriverService
    {
        private readonly HttpClient httpClient;

        public F1DriverService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<F1DriversDomainModel>> GetDrivers()
        {
            var response = await httpClient.GetAsync("api/f1/2019/1/results.json");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var jDoc = JsonDocument.Parse(json);
                var prop = jDoc.RootElement.GetProperty("constructorId").GetString();
                
                return new List<F1DriversDomainModel>();
            }
            else
            {
                var errorCode = Enum.GetName(typeof(HttpStatusCode), response.StatusCode);
                throw new HttpRequestException(errorCode);
            }
        }
        
        public Task<IEnumerable<F1DriversDomainModel>> GetDriversByTeam(string team)
        {
            throw new NotImplementedException();
        }
    }
}