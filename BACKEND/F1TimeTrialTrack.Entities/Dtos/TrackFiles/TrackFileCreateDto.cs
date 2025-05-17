using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1TimeTrialTrack.Entities.Dtos.TrackFiles
{
    public class TrackFileCreateDto
    {
        public required string FileName { get; set; } = "";
        public required string FileExtension { get; set; } = "";
        public required string FilePath { get; set; } = "";
    }
}
