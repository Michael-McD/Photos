using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoAlbum.api.Services
{
    public interface IPhotoAlbumService
    {
        Task<IEnumerable<AlbumDomainModel>> GetAlbums();
        Task<IEnumerable<PhotoDomainModel>> GetPhotos();
    }
}