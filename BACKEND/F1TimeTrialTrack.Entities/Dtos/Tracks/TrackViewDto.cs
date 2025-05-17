using F1TimeTrialTrack.Entities.Dtos.TracksRating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1TimeTrialTrack.Entities.Dtos.Tracks
{
    public class TrackViewDto
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public double Length { get; set; } = 0;
        public IEnumerable<TrackRatingViewDto>? Ratings { get; set; } 
        public int RatingCount => Ratings?.Count() ?? 0;
        public double AverageRating => Ratings?.Count() > 0 ? Ratings.Average(r => r.Rating) : 0;
    }
}
