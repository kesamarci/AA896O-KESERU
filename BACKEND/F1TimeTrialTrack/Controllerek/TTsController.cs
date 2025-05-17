using F1TimeTrialTrack.Entities.Dtos.TTs;
using F1TimeTrialTrack.Logic.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace F1TimeTrialTrack.Controllerek
{
    [Route("api/[controller]")]
    [ApiController]
    public class TTsController : ControllerBase
    {
        TTsLogic logic;
        public TTsController(TTsLogic logic)
        {
            this.logic = logic;
        }

        [HttpPost]
        [Authorize]
        public void AddTTs(TTsCCreateUpdateDto tTs)
        {
            logic.AddTTs(tTs);
        }
        [HttpGet]
        public IEnumerable<TTsViewDto> GetAllTTs()
        {
            return logic.GetAllTTs();
        }

        [HttpGet("{id}")]
        public TTsViewDto GetTTs(string id)
        {
            return logic.GetTTs(id);
        }


        [HttpPut("{id}")]
        [Authorize]
        public void UpdateTTs(string id,[FromBody] TTsCCreateUpdateDto tTs)
        {
            logic.UpdateTTs(id, tTs);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public void DeleteTTs(string id)
        {
            logic.DeleteTTs(id);
        }


    }
}
