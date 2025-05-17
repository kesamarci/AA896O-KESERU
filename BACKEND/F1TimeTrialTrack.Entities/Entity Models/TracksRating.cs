using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F1TimeTrialTrack.Entities.Helpers;

namespace F1TimeTrialTrack.Entities.Entity_Models
{
    public class TracksRating : IIdEntity
    {
        public TracksRating( string trackId, int rating, string comment)
        {
            Id = Guid.NewGuid().ToString();
            TrackId = trackId;
            Rating = rating;
            Comment = comment;
        }

        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string TrackId { get; set; }

        public string UserId { get; set; }
        [Range(1,10)]
        public int Rating { get; set; }
        public string Comment { get; set; }
        [NotMapped]
        public virtual Tracks? Track { get; set; }
       
    }
}
