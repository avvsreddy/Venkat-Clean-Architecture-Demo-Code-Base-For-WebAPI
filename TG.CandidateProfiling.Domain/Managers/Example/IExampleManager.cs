/*
 * Author: Venkat Shiva Reddy
 * Date: 24/06/2021
 * Email: venkat@pratian.com
 */


using System.Collections.Generic;
using System.Threading.Tasks;
using Example.Domain.ApiModels;

namespace Example.Domain.Manager
{
    public interface IExampleManager
    {
        #region Sync Methods
        IEnumerable<AlbumApiModel> GetAllAlbum();
        AlbumApiModel GetAlbumById(int id);
        IEnumerable<AlbumApiModel> GetAlbumByArtistId(int id);

        AlbumApiModel AddAlbum(AlbumApiModel newAlbumApiModel);

        bool UpdateAlbum(AlbumApiModel albumApiModel);
        bool DeleteAlbum(int id);
        #endregion

        #region Async Methods
        Task<IEnumerable<AlbumApiModel>> GetAllAlbumAsync();
        Task<AlbumApiModel> GetAlbumByIdAsync(int id);
        Task<IEnumerable<AlbumApiModel>> GetAlbumByArtistIdAsync(int id);

        Task<AlbumApiModel> AddAlbumAsync(AlbumApiModel newAlbumApiModel);

        Task<bool> UpdateAlbumAsync(AlbumApiModel albumApiModel);
        Task<bool> DeleteAlbumAsync(int id);
        #endregion

    }
}