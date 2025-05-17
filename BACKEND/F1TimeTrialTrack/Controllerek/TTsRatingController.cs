using F1TimeTrialTrack.Data;
using F1TimeTrialTrack.Entities.Dtos.TTsRating;
using F1TimeTrialTrack.Logic.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace F1TimeTrialTrack.Controllerek
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TTsRatingController : ControllerBase
    {
        TTsRatingLogic logic;
        UserManager<AppUser> userManager;
        
        public TTsRatingController(TTsRatingLogic logic, UserManager<AppUser> userManager)
        {
            this.logic = logic;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task AddRating(TTsRatingCreateDto dto)
        {
            var user = await userManager.GetUserAsync(User);
            logic.AddRating(dto, user.Id);
        }
    }
}
