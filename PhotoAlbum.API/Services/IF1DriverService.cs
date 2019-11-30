using System.Collections.Generic;
using System.Threading.Tasks;
using PhotoAlbum.API.Models;

namespace PhotoAlbum.api.Services
{
    public interface IF1DriverService
    {
        Task<IEnumerable<F1DriversDomainModel>> GetDrivers();
        Task<IEnumerable<F1DriversDomainModel>> GetDriversByTeam(string team);
    }
}