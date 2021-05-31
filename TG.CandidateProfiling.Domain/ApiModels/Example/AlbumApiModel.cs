/*
 * Author: Venkat Shiva Reddy
 * Date: 24/06/2022
 * Email: venkat@pratian.com
 */


using Example.Domain.Entities;
using System.Collections.Generic;
using TG.CandidateProfiling.Domain.Converters;

namespace Example.Domain.ApiModels
{
    public class AlbumApiModel : IConvertModel<AlbumApiModel, Album>
    {
        public int AlbumId { get; set; }
        public string Title { get; set; } 
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public ArtistApiModel Artist { get; set; }

        public Album Convert() =>
            new Album
            {
                AlbumId = AlbumId,
                ArtistId = ArtistId,
                Title = Title
            };
    }
}