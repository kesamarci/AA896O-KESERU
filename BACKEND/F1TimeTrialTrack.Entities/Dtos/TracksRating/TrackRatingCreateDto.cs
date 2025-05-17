using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1TimeTrialTrack.Entities.Dtos.TracksRating
{
    public class TrackRatingCreateDto
    {
        public required string TrackId { get; set; }
        [MinLength(10)]
        [MaxLength(1000)]
        public required string Comment { get; set; } = "";
        [Range(1,10)]
        public required int Rating { get; set; } = 0;
    }
}
