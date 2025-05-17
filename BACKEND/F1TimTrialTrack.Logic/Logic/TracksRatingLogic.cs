using F1TimeTrialTrack.Data;
using F1TimeTrialTrack.Entities.Dtos.TracksRating;
using F1TimeTrialTrack.Entities.Entity_Models;
using F1TimeTrialTrack.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1TimeTrialTrack.Logic.Logic
{
    public class TracksRatingLogic
    {
        Repository<TracksRating> repo;
        DtoProvider dtoProvider;
        public TracksRatingLogic(Repository<TracksRating> repo, DtoProvider dtoProvider)
        {
            this.repo = repo;
            this.dtoProvider = dtoProvider;
        }
        public void AddRating(TrackRatingCreateDto dto, string userId)
        {
          var model = dtoProvider.Mapper.Map<TracksRating>(dto);
            model.UserId = userId;
            repo.Create(model);
        }
    }
}
