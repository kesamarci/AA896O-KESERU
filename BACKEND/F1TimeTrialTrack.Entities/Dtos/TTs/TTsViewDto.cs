using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1TimeTrialTrack.Entities.Dtos.TTs
{
    public class TTsViewDto
    {
        public string Id { get; set; } = "";
        public string TrackName { get; set; } = "";
        public string Car { get; set; } = "";
        public string Driver { get; set; } = "";
        public string Time { get; set; } = "";
        public DateTime Date { get; set; }
        public string Platform { get; set; } = "";
        public string Tire { get; set; } = "";
        public string Assist { get; set; } = "";
        public string Setup { get; set; } = "";
        public string Wheather { get; set; } = "";
        public double AvaerageRating { get; set; } = 0;
    }
}
