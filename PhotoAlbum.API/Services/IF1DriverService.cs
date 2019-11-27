using System.Collections.Generic;
using PhotoAlbum.API.Models;

namespace PhotoAlbum.api.Services
{
    public interface IF1DriverService
    {
        IEnumerable<F1DriversDomainModel> GetDrivers();
        IEnumerable<F1DriversDomainModel> GetDriversByTeam(string team);
    }
}