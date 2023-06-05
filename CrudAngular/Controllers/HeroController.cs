using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        [HttpGet]

        public async Task<ActionResult<List<Hero>>> GetHero()
        {
            return new List<Hero>
            {
                new Hero
                {
                    HeroName = "Spider Man",
                    FirstName = "Peter",
                    Lastname = "Parker",
                    Place = "New York",
                }
            };
        }
    }
}
