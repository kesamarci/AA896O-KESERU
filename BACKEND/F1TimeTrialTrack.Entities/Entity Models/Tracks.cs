using F1TimeTrialTrack.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace F1TimeTrialTrack.Entities.Entity_Models
{
    public class Tracks : IIdEntity
    {
        public Tracks(string name, double length)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Length = length;
        }
        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        public double Length { get; set; }
        

        public virtual ICollection<TracksRating> TracksRatings { get; set; }
        public virtual ICollection<TrackFile> TrackFiles { get; set; }


    }
}
