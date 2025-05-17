using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1TimeTrialTrack.Entities.Dtos.Tracks
{
    public class TrackShortViewDto
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public double Length { get; set; } = 0;
        public double AvarageRating { get; set; } = 0;

    }
}
