using ASPNETCoreAPI.Models.Dto;

namespace ASPNETCoreAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO> {
                new VillaDTO{Id=1, Name="Galadari", Occupancy = 4, Sqft=100},
                new VillaDTO{Id=2, Name="Niladari", Occupancy = 5, Sqft=200},
        };
    }
}
