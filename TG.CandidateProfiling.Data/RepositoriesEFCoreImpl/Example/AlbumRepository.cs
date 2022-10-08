/*
 * Author: Venkat Shiva Reddy
 * Date: 24/06/2021
 * Email: venkat@pratian.com
 */

using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Example.Domain.Repositories;
using Example.Domain.Entities;
using System.Threading.Tasks;

namespace Example.Data.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly ExampleAlbumDBContext _context;

        public AlbumRepository(ExampleAlbumDBContext context)
        {
            _context = context;
        }

        private bool AlbumExists(int id) =>
            _context.Albums.Any(a => a.AlbumId == id);

        public void Dispose() => _context.Dispose();

        public List<Album> GetAll() => _context.Albums.AsNoTracking().ToList();

        public Album GetById(int id)
        {
            var dbAlbum = _context.Albums.Find(id);
            return dbAlbum;
        }

        public Album Add(Album newAlbum)
        {
            _context.Albums.Add(newAlbum);
            _context.SaveChanges();
            return newAlbum;
        }

        public bool Update(Album album)
        {
            if (!AlbumExists(album.AlbumId))
                return false;
            _context.Albums.Update(album);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            if (!AlbumExists(id))
                return false;
            var toRemove = _context.Albums.Find(id);
            _context.Albums.Remove(toRemove);
            _context.SaveChanges();
            return true;
        }

        public List<Album> GetByArtistId(int id) =>
            _context.Albums.Where(a => a.ArtistId == id).ToList();

        public async Task<List<Album>> GetAllAsync()
        {
            return await _context.Albums.AsNoTracking().ToListAsync();
        }

        public async Task<Album> GetByIdAsync(int id)
        {
            return await _context.Albums.FindAsync(id);
        }

        public async Task<List<Album>> GetByArtistIdAsync(int id)
        {
            return await _context.Albums.Where(a => a.ArtistId == id).ToListAsync();
        }

        public async Task<Album> AddAsync(Album newAlbum)
        {
            _context.Albums.Add(newAlbum);
            await _context.SaveChangesAsync();
            return newAlbum;
        }

        public async Task<bool> UpdateAsync(Album album)
        {
            if (!AlbumExists(album.AlbumId))
                return false;
            _context.Albums.Update(album);
           await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!AlbumExists(id))
                return false;
            var toRemove = await _context.Albums.FindAsync(id);
            _context.Albums.Remove(toRemove);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}