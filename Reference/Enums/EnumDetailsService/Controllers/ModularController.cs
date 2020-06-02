using EnumDetailsService.Enums;
using EnumDetailsService.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnumDetailsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModularController : ControllerBase
    {
        [HttpGet]
        public ActionResult<ModularSynth> Get()
        {
            var module = new ModularSynth
            {
                Name = "Tides",
                ReleaseDate = "2017",
                Type = ModularTypes.Modulator
            };

            return module;
        }
    }
}