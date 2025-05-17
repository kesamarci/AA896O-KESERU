using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1TimeTrialTrack.Entities.Dtos.Tracks
{
    public class TracksCreateUpdateDto
    {
        public required string Name { get; set; } = "";
        public required double Length { get; set; } = 0;

       


    }
}
