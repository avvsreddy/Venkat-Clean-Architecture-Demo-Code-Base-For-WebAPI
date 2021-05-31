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
    public class ArtistApiModel : IConvertModel<ArtistApiModel, Artist>
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public IList<AlbumApiModel> Albums { get; set; }

        public Artist Convert() =>
            new Artist
            {
                ArtistId = ArtistId,
                Name = Name
            };
    }
}