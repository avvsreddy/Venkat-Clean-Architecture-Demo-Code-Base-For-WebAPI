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
    public interface IArtistRepository : IDisposable
    {

#region Sync Methods
        List<Artist> GetAll();
        Artist GetById(int id);
        Artist Add(Artist newArtist);
        bool Update(Artist artist);
        bool Delete(int id);
#endregion

#region Async Methods
        Task<List<Artist>> GetAllAsync();
        Task<Artist> GetByIdAsync(int id);
        Task<Artist> AddAsync(Artist newArtist);
        Task<bool> UpdateAsync(Artist artist);
        Task<bool> DeleteAsync(int id);
#endregion
    }
}