using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Models.Responses;
using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Models.Validation;
using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Services;
using Havbruksloggen_Coding_Challenge.Shared.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Controllers
{
    [Route("api/crew")]
    [ApiController]
    public class CrewController : ControllerBase
    {
        private readonly ICrewService _crewService;
        public CrewController(ICrewService crewService)
        {
            _crewService = crewService;
        }

        [HttpPost("/api/crew/create")]
        public IActionResult CreateABoat(CreateCrewMemberSchema model)
        {
            HttpResponse<CrewMemberResponse> response = new HttpResponse<CrewMemberResponse>();
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            response.Result = _crewService.Create(model);

            return Ok(response);
        }

        [HttpPut("/api/crew/update")]
        public IActionResult Update(CreateCrewMemberSchema model, string id)
        {
            HttpResponse<CrewMemberResponse> response = new HttpResponse<CrewMemberResponse>();
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);
            Console.WriteLine(model.Name);
            response.Result = _crewService.Update(model, id);

            return Ok(response);
        }

        [HttpGet("/api/crew/all")]
        public JsonResult GetAllCrewMembers()
        {
            HttpResponse<List<CrewMemberResponse>> response = new HttpResponse<List<CrewMemberResponse>>();
            var result = _crewService.GetAll();
            response.Result = result;
            //return Ok(response);
            Console.WriteLine(response);
            return new JsonResult(response);
        }

        [HttpDelete("/api/crew/delete")]
        public IActionResult DelateABoat(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            _crewService.Delete(id);

            return Ok();
        }
    }
}
