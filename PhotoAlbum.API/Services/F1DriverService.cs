using System;
using System.Collections.Generic;
using System.Net.Http;
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

        public IEnumerable<F1DriversDomainModel> GetDrivers()
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<F1DriversDomainModel> GetDriversByTeam(string team)
        {
            throw new NotImplementedException();
        }
    }
}