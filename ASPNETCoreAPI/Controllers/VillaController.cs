using ASPNETCoreAPI.Data;
using ASPNETCoreAPI.Logging;
using ASPNETCoreAPI.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreAPI.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/villa")]
    public class VillaController : ControllerBase
    {
        public readonly ILogging _logger;
        public VillaController(ILogging logger)
        {
            _logger = logger;   
        }

        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            _logger.Log("Getting All Villas", "");
            return Ok(VillaStore.villaList);
        }

        [HttpGet("{id:int}", Name = "GetaVilla")]

        public ActionResult<VillaDTO> GetVillasById(int id)
        {
            if (id == 0)
            {
                _logger.Log("Getting a Villa with id " + id , "error");
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            if (villaDTO == null)
            {
                return BadRequest();
            }
            if (villaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villaDTO.Id = VillaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            VillaStore.villaList.Add(villaDTO);

            return Ok(villaDTO);
        }
        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        public IActionResult DeleteVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            VillaStore.villaList.Remove(villa);
            return Ok();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        public IActionResult UpdateVilla(int id, [FromBody]VillaDTO villaDTO)
        {
            if(villaDTO == null || id != villaDTO.Id)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            villa.Name = villaDTO.Name;
            villa.Occupancy = villaDTO.Occupancy;   
            villa.Sqft = villaDTO.Sqft;
            return Ok();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if(villa == null)
            {
                return BadRequest();
            }
            patchDto.ApplyTo(villa, ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
} 
