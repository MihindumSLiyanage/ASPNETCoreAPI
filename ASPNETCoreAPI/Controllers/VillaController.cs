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
    }
} 
