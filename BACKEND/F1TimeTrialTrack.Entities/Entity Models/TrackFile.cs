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
    public class TrackFile : IIdEntity
    {
        public TrackFile(string fileName, string fileExtension, string filePath, string trackId)
        {
            Id = Guid.NewGuid().ToString();
            FileName = fileName;
            FileExtension = fileExtension;
            FilePath = filePath;
            TrackId = trackId;
        }
        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = "";
        public string FileName { get; set; } = "";
        public string FileExtension { get; set; } = "";
        public string FilePath { get; set; } = "";
        public string TrackId { get; set; } = "";
        [NotMapped]
        public virtual Tracks? Track { get; set; }
    }
}
