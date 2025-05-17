using F1TimeTrialTrack.Data;
using F1TimeTrialTrack.Entities.Dtos.TrackFiles;
using F1TimeTrialTrack.Entities.Entity_Models;
using F1TimeTrialTrack.Logic.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1TimeTrialTrack.Logic.Logic
{
    public class TrackFileLogic 
    {
        Repository<TrackFile> repo;
        DtoProvider dtoProvider;
        public TrackFileLogic(Repository<TrackFile> repo, DtoProvider dtoProvider)
        {
            this.repo = repo;
            this.dtoProvider = dtoProvider;
        }
        public void AddTrackFile(TrackFileCreateDto dto)
        {
            var model = dtoProvider.Mapper.Map<TrackFile>(dto);
            repo.Create(model);
        }
        public IEnumerable<TrackFileViewDto> GetAllTrackFiles()
        {
            var models = repo.GetAll();
            return dtoProvider.Mapper.Map<IEnumerable<TrackFileViewDto>>(models);
        }
        public void DeleteTrackFile(string id)
        {
            repo.DeleteById(id);
        }
        public string Upload(IFormFile file)
        {
            //extension check
            List<string> valide = new List<string>() { ".jpg", ".png", ".gif", ".jpeg" };
            var extension = Path.GetExtension(file.FileName);
            if (!valide.Contains(extension))
            {
                return $"Fájlformátum nem megfelelő!!({string.Join(',', valide)})";
            }

            //size check
            if (file.Length > 10 * 1024 * 1024)
            {
                return "Fájl mérete túl nagy!(nagyobb mint 10Mb)";
            }
            string fileName = Guid.NewGuid().ToString() + extension;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            using FileStream fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
            file.CopyTo(fileStream);
            return fileName;
        }


    }
}
