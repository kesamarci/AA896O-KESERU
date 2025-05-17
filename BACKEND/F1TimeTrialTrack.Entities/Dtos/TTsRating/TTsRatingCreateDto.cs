using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1TimeTrialTrack.Entities.Dtos.TTsRating
{
    public class TTsRatingCreateDto
    {
        public required string TTsId { get; set; } = "";
        [Range(1,10)]
        public required int Rating { get; set; }
        [MinLength(10)]
        public string Comment { get; set; } = "";

    }
}
