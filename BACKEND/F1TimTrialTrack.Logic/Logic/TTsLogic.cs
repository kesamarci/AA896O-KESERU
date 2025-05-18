using F1TimeTrialTrack.Data;
using F1TimeTrialTrack.Entities.Dtos.TTs;
using F1TimeTrialTrack.Entities.Entity_Models;
using F1TimeTrialTrack.Logic.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1TimeTrialTrack.Logic.Logic
{
    public class TTsLogic
    {
        Repository<TTs> repo;
        DtoProvider dtoProvider;
        public TTsLogic(Repository<TTs> repo, DtoProvider dtoProvider)
        {
            this.repo = repo;
            this.dtoProvider = dtoProvider;
        }

        private int ConvertTimeStringToMillis(string timeString)
        {
            var parts = timeString.Split(':');
            if (parts.Length != 2) throw new FormatException("Invalid time format");

            int minutes = int.Parse(parts[0]);
            var secParts = parts[1].Split('.');
            int seconds = int.Parse(secParts[0]);
            int millis = int.Parse(secParts[1]);

            return (minutes * 60 * 1000) + (seconds * 1000) + millis;
        }

        public double? GetAverageTimeByTrack(string trackName)
        {

            var times = repo.GetAll()
                           .Where(tt => tt.TrackName == trackName)
                           .Select(tt => tt.TimeInMillis)
                           .ToList();

            if (times.Count == 0)
                return null;

            return times.Average();
        }
        public void AddTTs(TTsCCreateUpdateDto dto)//nincs update mert csak 1 TT lehet egy fiókhoz,
        {



            TTs ts = dtoProvider.Mapper.Map<TTs>(dto);
            ts.TimeInMillis = ConvertTimeStringToMillis(dto.Time);
            
            //if (repo.GetAll().FirstOrDefault(x => x.TrackName == ts.TrackName) == null)
            //{
            //    repo.Create(ts);
            //}
            //else
            //{
            //    throw new ArgumentException("Te már csak Updatelni tudsz, egy fiók csak egy TT idővel rendelkezhet egy pályához");
            //}
            bool alreadyExists = repo.GetAll()
                .Any(x => x.TrackName == ts.TrackName && x.Id == ts.Id);
            if (!alreadyExists)
            {
                repo.Create(ts);
            }
            else
            {
                throw new ArgumentException("Ez a felhasználó már rendelkezik TT idővel ezen a pályán.");
            }

        }
        public IEnumerable<TTsShortViewDto> GetAllTTs()
        {

            var all = repo.GetAll();
            var result = new List<TTsShortViewDto>();

            foreach (var tt in all)
            {
                var dto = dtoProvider.Mapper.Map<TTsShortViewDto>(tt);
                dto.AverageTime = GetAverageTimeByTrack(tt.TrackName);
                result.Add(dto);
            }

            return result;
        }
        public TTsViewDto GetTTs(string id)
        {
            var ts = repo.FindById(id);
            var dto = dtoProvider.Mapper.Map<TTsViewDto>(ts);
            return dto;
        
        }
        public void UpdateTTs(string id, TTsCCreateUpdateDto dto)
        {
            var model = repo.FindById(id);
            dtoProvider.Mapper.Map(dto, model);
            repo.Update(model);
        }
        public void DeleteTTs(string id)
        {
            repo.DeleteById(id);
        }
    }
}
