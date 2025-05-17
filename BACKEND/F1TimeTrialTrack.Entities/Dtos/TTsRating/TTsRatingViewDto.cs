using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1TimeTrialTrack.Entities.Dtos.TTsRating
{
    public class TTsRatingViewDto
    {
        public string Comment { get; set; } = "";
        public int Rating { get; set; }
        public string UserFullName { get; set; } = "";
    }
}
