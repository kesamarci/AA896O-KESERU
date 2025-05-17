using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1TimeTrialTrack.Entities.Dtos.TTs
{
    public class TTsCCreateUpdateDto
    {

        public required string TrackName { get; set; } = "";
        public required string Car { get; set; } = "";
        public required string Driver { get; set; } = "";
        public required string Time { get; set; } = "";
        public required DateTime Date { get; set; }
        public required string Platform { get; set; } = "";
        public required string Tire { get; set; } = "";
        public required string Assist { get; set; } = "";
        public required string Setup { get; set; } = "";
        public required string Wheather { get; set; } = "";
    }
}
