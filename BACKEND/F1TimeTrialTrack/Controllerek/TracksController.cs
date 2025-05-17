using F1TimeTrialTrack.Entities.Dtos.Tracks;
using F1TimeTrialTrack.Helpers;
using F1TimeTrialTrack.Logic.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace F1TimeTrialTrack.Controllerek
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        TracksLogic logic;

        public TracksController(TracksLogic logic)
        {
            this.logic = logic;
        }
        [HttpPost]
        [Authorize]
        public void AddTrack(TracksCreateUpdateDto track)
        {
            logic.AddTrack(track);
        }
        [HttpGet]
        public IEnumerable<TrackShortViewDto> GetAllTracks()
        {
            return logic.GetAllTracks();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public void DeleteTrack(string id)
        {
            logic.DeleteTrack(id);
        }
        [HttpPut("{id}")]
        [Authorize]
        public void UpdateTrack(string id, [FromBody] TracksCreateUpdateDto track)
        {
            logic.UpdateTrack(id, track);
        }
        [HttpGet("{id}")]
        public TrackViewDto GetTrack(string id)
        {
            return logic.GetTrack(id);
        }
        

    }
}
