using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1TimeTrialTrack.Entities.Dtos.TrackFiles
{
    public class TrackFileViewDto
    {
        public string Id { get; set; } = "";
        public string FileName { get; set; } = "";
        public string FileExtension { get; set; } = "";
        public string FilePath { get; set; } = "";
    }
}
