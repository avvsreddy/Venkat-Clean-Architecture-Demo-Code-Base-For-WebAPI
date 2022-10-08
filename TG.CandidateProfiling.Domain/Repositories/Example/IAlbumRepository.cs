/*
 * Author: Venkat Shiva Reddy
 * Date: 24/06/2021
 * Email: venkat@pratian.com
 */

using Example.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Domain.Repositories
{
    public interface IAlbumRepository : IDisposable
    {

#region Sync Methods
        List<Album> GetAll();
        Album GetById(int id);
        List<Album> GetByArtistId(int id);
        Album Add(Album newAlbum);
        bool Update(Album album);
        bool Delete(int id);
        #endregion

#region Async Methods
        Task<List<Album>> GetAllAsync();
        Task<Album> GetByIdAsync(int id);
        Task<List<Album>> GetByArtistIdAsync(int id);
        Task<Album> AddAsync(Album newAlbum);
        Task<bool> UpdateAsync(Album album);
        Task<bool> DeleteAsync(int id);
#endregion
    }
}