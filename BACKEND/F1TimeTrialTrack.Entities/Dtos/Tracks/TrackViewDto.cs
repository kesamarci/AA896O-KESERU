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

        public int RatingCount { get; set; } = 0;
        public double AverageRating { get; set; } = 0;

    }
}
