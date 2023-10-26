using ASPNETCoreAPI.Data;
using ASPNETCoreAPI.Models;
using ASPNETCoreAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreAPI.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/villa")]
    public class VillaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok(VillaStore.villaList);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<VillaDTO> GetVillasById(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if(villa == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
            villaDTO.Id = VillaStore.villaList.OrderByDescending(u=>u.Id).FirstOrDefault().Id + 1;
            VillaStore.villaList.Add(villaDTO);
            
            return Ok(villaDTO);    
        }
    }
} 
