/*
 * Author: Venkat Shiva Reddy
 * Date: 24/06/2022
 * Email: venkat@pratian.com
 */

using Example.Domain.ApiModels;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using TG.CandidateProfiling.Domain.Converters;

namespace Example.Domain.Entities
{
    public class Artist : IConvertModel<Artist, ArtistApiModel>
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
        }

        public int ArtistId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Album> Albums { get; set; }
        
        public ArtistApiModel Convert() =>
            new ArtistApiModel
            {
                ArtistId = ArtistId,
                Name = Name
            };
    }
}