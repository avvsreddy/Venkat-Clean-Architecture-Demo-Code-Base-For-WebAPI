/*
 * Author: Venkat Shiva Reddy
 * Date: 24/06/2022
 * Email: venkat@pratian.com
 */


using Example.Domain.ApiModels;
using Example.Domain.Repositories;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Domain.Manager
{
    public partial class ExampleManager : IExampleManager
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IMemoryCache _cache;

        public ExampleManager()
        {
        }

        public ExampleManager(IAlbumRepository albumRepository,
            IArtistRepository artistRepository,
            
            IMemoryCache memoryCache
        )
        {
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
           
            _cache = memoryCache;
        }

        
    }
}