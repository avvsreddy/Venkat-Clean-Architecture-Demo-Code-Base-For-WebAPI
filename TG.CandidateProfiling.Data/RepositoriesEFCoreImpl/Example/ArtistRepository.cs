/*
 * Author: Venkat Shiva Reddy
 * Date: 24/06/2021
 * Email: venkat@pratian.com
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Example.Domain.Entities;
using Example.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Data.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ExampleAlbumDBContext _context;

        public ArtistRepository(ExampleAlbumDBContext context)
        {
            _context = context;
        }

        private bool ArtistExists(int id) =>
            _context.Artists.Any(a => a.ArtistId == id);

        public void Dispose() => _context.Dispose();

        public List<Artist> GetAll() =>
            _context.Artists.AsNoTracking().ToList();

        public Artist GetById(int id) =>
            _context.Artists.Find(id);

        public Artist Add(Artist newArtist)
        {
            _context.Artists.Add(newArtist);
            _context.SaveChanges();
            return newArtist;
        }

        public bool Update(Artist artist)
        {
            if (!ArtistExists(artist.ArtistId))
                return false;
            _context.Artists.Update(artist);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            if (!ArtistExists(id))
                return false;
            var toRemove = _context.Artists.Find(id);
            _context.Artists.Remove(toRemove);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<Artist>> GetAllAsync()
        {
            return await _context.Artists.AsNoTracking().ToListAsync();
        }

        public async Task<Artist> GetByIdAsync(int id)
        {
            return await _context.Artists.FindAsync(id);
        }

        public async Task<Artist> AddAsync(Artist newArtist)
        {
            _context.Artists.Add(newArtist);
            await _context.SaveChangesAsync();
            return newArtist;
        }

        public async Task<bool> UpdateAsync(Artist artist)
        {
            if (!ArtistExists(artist.ArtistId))
                return false;
            _context.Artists.Update(artist);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!ArtistExists(id))
                return false;
            var toRemove = await _context.Artists.FindAsync(id);
            _context.Artists.Remove(toRemove);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}