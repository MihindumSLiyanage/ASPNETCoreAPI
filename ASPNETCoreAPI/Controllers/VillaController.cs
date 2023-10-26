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
        public IEnumerable<VillaDTO> GetVillas()
        {
            return VillaStore.villaList;
        }

        [HttpGet("{id:int}")]
        public VillaDTO GetVillasById(int id)
        {
            return VillaStore.villaList.FirstOrDefault(u=>u.Id==id);
        }
    }
} 
