/*
 * Author: Venkat Shiva Reddy
 * Date: 24/06/2022
 * Email: venkat@pratian.com
 */

using Example.Domain.ApiModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TG.CandidateProfiling.Domain.Converters;

namespace Example.Domain.Entities
{
    public class Album : IConvertModel<Album, AlbumApiModel>
    {
        
        [Key]
        public int AlbumId { get; set; }
        
        [StringLength(160, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }
        public int ArtistId { get; set; }

        [JsonIgnore]
        public virtual Artist Artist { get; set; }

        public AlbumApiModel Convert() =>
            new AlbumApiModel
            {
                AlbumId = AlbumId,
                ArtistId = ArtistId,
                Title = Title,
                ArtistName = Artist.Name
            };
    }
}