using F1TimeTrialTrack.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1TimeTrialTrack.Entities.Entity_Models
{
    public class TTsRating : IIdEntity
    {
        public TTsRating( string tTsId, int rating, string comment)
        {
            Id = Guid.NewGuid().ToString();
            TTsId = tTsId;
            Rating = rating;
            Comment = comment;
        }
        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string TTsId { get; set; }
        [Range(1,10)]
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
        [NotMapped]
        public virtual TTs? TTs { get; set; }

    }
}
