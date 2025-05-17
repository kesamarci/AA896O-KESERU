using F1TimeTrialTrack.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1TimeTrialTrack.Entities.Entity_Models
{
    public class TTs : IIdEntity
    {
        public TTs( string trackName, string car, string driver, string time, DateTime date, string platform, string tire, string assist, string setup, string wheather)
        {
            Id = Guid.NewGuid().ToString();
            TrackName = trackName;
            Car = car;
            Driver = driver;
            Time = time;
            Date = date;
            Platform = platform;
            Tire = tire;
            Assist = assist;
            Setup = setup;
            Wheather = wheather;
        }
        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string TrackName { get; set; }
        public string Car { get; set; }
        public string Driver { get; set; }
        public string Time { get; set; }
        public DateTime Date { get; set; }
        public string Platform { get; set; }
        public string Tire { get; set; }
        public string Assist { get; set; }
        public string Setup { get; set; }
        public string Wheather { get; set; }
        [NotMapped]
        public virtual ICollection<TTsRating> TTsRatings { get; set; }
    }
}
