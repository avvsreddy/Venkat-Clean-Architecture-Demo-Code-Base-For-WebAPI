/*
 * Author: Venkat Shiva Reddy
 * Date: 24/06/2022
 * Email: venkat@pratian.com
 */


using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Example.Domain.ApiModels;
using TG.CandidateProfiling.Domain.Extensions;
using System.Threading.Tasks;

namespace Example.Domain.Manager
{
    public partial class ExampleManager
    {
        public IEnumerable<AlbumApiModel> GetAllAlbum()
        {
            var albums = _albumRepository.GetAll().ConvertAll();
            foreach (var album in albums)
            {
                var cacheEntryOptions =
                    new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(string.Concat("Album-", album.AlbumId), album, cacheEntryOptions);
            }

            return albums;
        }

        public AlbumApiModel GetAlbumById(int id)
        {
            var albumApiModelCached = _cache.Get<AlbumApiModel>(string.Concat("Album-", id));

            if (albumApiModelCached != null)
            {
                return albumApiModelCached;
            }
            else
            {
                var album = _albumRepository.GetById(id);
                if (album == null) return null;
                var albumApiModel = album.Convert();
                albumApiModel.ArtistName = (_artistRepository.GetById(albumApiModel.ArtistId)).Name;

                var cacheEntryOptions =
                    new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(string.Concat("Album-", albumApiModel.AlbumId), albumApiModel, cacheEntryOptions);

                return albumApiModel;
            }
        }

        public IEnumerable<AlbumApiModel> GetAlbumByArtistId(int id)
        {
            var albums = _albumRepository.GetByArtistId(id);
            return albums.ConvertAll();
        }

        public AlbumApiModel AddAlbum(AlbumApiModel newAlbumApiModel)
        {
            var album = newAlbumApiModel.Convert();

            album = _albumRepository.Add(album);
            newAlbumApiModel.AlbumId = album.AlbumId;
            return newAlbumApiModel;
        }

        public bool UpdateAlbum(AlbumApiModel albumApiModel)
        {
            var album = _albumRepository.GetById(albumApiModel.AlbumId);

            if (album is null) return false;
            album.AlbumId = albumApiModel.AlbumId;
            album.Title = albumApiModel.Title;
            album.ArtistId = albumApiModel.ArtistId;

            return _albumRepository.Update(album);
        }

        public bool DeleteAlbum(int id)
            => _albumRepository.Delete(id);

        public async Task<AlbumApiModel> AddAlbumAsync(AlbumApiModel newAlbumApiModel)
        {
            var album = newAlbumApiModel.Convert();

            album = await _albumRepository.AddAsync(album);
            newAlbumApiModel.AlbumId = album.AlbumId;
            return newAlbumApiModel;
        }

        public async Task<bool> DeleteAlbumAsync(int id)
        {
            return await _albumRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AlbumApiModel>> GetAlbumByArtistIdAsync(int id)
        {
            var albums = await _albumRepository.GetByArtistIdAsync(id);
            return albums.ConvertAll();
        }

        public async Task<AlbumApiModel> GetAlbumByIdAsync(int id)
        {
            var albumApiModelCached = _cache.Get<AlbumApiModel>(string.Concat("Album-", id));

            if (albumApiModelCached != null)
            {
                return albumApiModelCached;
            }
            else
            {
                var album = await _albumRepository.GetByIdAsync(id);
                if (album == null) return null;
                var albumApiModel = album.Convert();
                albumApiModel.ArtistName = (await _artistRepository.GetByIdAsync(albumApiModel.ArtistId)).Name;

                var cacheEntryOptions =
                    new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(string.Concat("Album-", albumApiModel.AlbumId), albumApiModel, cacheEntryOptions);

                return albumApiModel;
            }
        }

        public async Task<IEnumerable<AlbumApiModel>> GetAllAlbumAsync()
        {
            var albums = (await _albumRepository.GetAllAsync()).ConvertAll();
            foreach (var album in albums)
            {
                var cacheEntryOptions =
                    new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(string.Concat("Album-", album.AlbumId), album, cacheEntryOptions);
            }

            return albums;
        }

        public async Task<bool> UpdateAlbumAsync(AlbumApiModel albumApiModel)
        {
            var album = await _albumRepository.GetByIdAsync(albumApiModel.AlbumId);

            if (album is null) return false;
            album.AlbumId = albumApiModel.AlbumId;
            album.Title = albumApiModel.Title;
            album.ArtistId = albumApiModel.ArtistId;

            return await _albumRepository.UpdateAsync(album);
        }
    }
}