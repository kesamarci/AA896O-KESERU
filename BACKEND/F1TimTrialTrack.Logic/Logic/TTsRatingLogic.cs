using F1TimeTrialTrack.Data;
using F1TimeTrialTrack.Entities.Dtos.TTsRating;
using F1TimeTrialTrack.Entities.Entity_Models;
using F1TimeTrialTrack.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1TimeTrialTrack.Logic.Logic
{
    public class TTsRatingLogic
    {
        Repository<TTsRating> repo;
        DtoProvider dtoProvider;
        public TTsRatingLogic(Repository<TTsRating> repo, DtoProvider dtoProvider)
        {
            this.repo = repo;
            this.dtoProvider = dtoProvider;
        }
        public void AddRating(TTsRatingCreateDto dto, string userId)
        {
           var model=dtoProvider.Mapper.Map<TTsRating>(dto);
            model.UserId = userId;
            repo.Create(model);
        }
    }
}
