using Example.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
/*
 * Author: Venkat Shiva Reddy
 * Date: 24/06/2022
 * Email: venkat@pratian.com
 */
using System.Text;



using System.Threading.Tasks;

namespace Example.Data
{
    public class ExampleAlbumDBContext : DbContext
    {
        public ExampleAlbumDBContext(DbContextOptions options) : base(options)
        {
            
            LoadSampleData();
        }

        private void LoadSampleData()
        {

            Artist a1 = new Artist { ArtistId = 1, Name = "Artist 1" };
            Artist a2 = new Artist { ArtistId = 2, Name = "Artist 2" };
            Artist a3 = new Artist { ArtistId = 3, Name = "Artist 3" };
            Artist a4 = new Artist { ArtistId = 4, Name = "Artist 4" };
            Artist a5 = new Artist { ArtistId = 5, Name = "Artist 5" };

            Album ab1 = new Album { AlbumId = 1, ArtistId = 1, Title = "Album 1" };
            Album ab2 = new Album { AlbumId = 2, ArtistId = 5, Title = "Album 2" };
            Album ab3 = new Album { AlbumId = 3, ArtistId = 2, Title = "Album 3" };
            Album ab4 = new Album { AlbumId = 4, ArtistId = 3, Title = "Album 4" };
            Album ab5 = new Album { AlbumId = 5, ArtistId = 4, Title = "Album 5" };
            if (Artists.Count() == 0)
            {
                Artists.AddRange(a1, a2, a3, a4, a5);
                Albums.AddRange(ab1, ab2, ab3, ab4, ab5);
                this.SaveChanges();
            }
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
    }
}
