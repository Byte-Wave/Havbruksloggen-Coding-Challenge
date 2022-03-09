using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Models.Responses;
using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Models.Validation;
using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Repositories;
using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Services;
using Havbruksloggen_Coding_Challenge.Shared.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BoatsController : ControllerBase
    {
        private IBoatService _boatService;
        public BoatsController(IBoatService boatService)
        {
            _boatService = boatService;
        }
        [HttpPost("/api/boats/create")]
        public IActionResult CreateABoat(CreateBoatSchema model)
        {
            HttpResponse<BoatResponse> response = new HttpResponse<BoatResponse>();
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            response.Result = _boatService.Create(model);
           
            return Ok(response);
        }
        [HttpDelete("/api/boats/delete")]
        public IActionResult DelateABoat(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            _boatService.Delete(id);

            return Ok();
        }
        [HttpPut("/api/boats/update")]
        public IActionResult Update(CreateBoatSchema model, string id)
        {
            HttpResponse<BoatResponse> response = new HttpResponse<BoatResponse>();
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            response.Result = _boatService.Create(model);

            return Ok(response);
        }


        [HttpGet("/api/boats/all")]
        public JsonResult GetAllBoats()
        {
            HttpResponse<List<BoatResponse>> response = new HttpResponse<List<BoatResponse>>();
            var result = _boatService.GetAll();
            response.Result = result;
            //return Ok(response);
            return new JsonResult(response);
        }

        [HttpGet("/api/boats/list")]
        public JsonResult List(int page, int itemsPerPage)
        {
            HttpResponse<List<BoatResponse>> response = new HttpResponse<List<BoatResponse>>();
            var result = _boatService.List(page, itemsPerPage);
            response.Result = result;

            return new JsonResult(response);
        }
    }
}
