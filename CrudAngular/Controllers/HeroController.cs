using CrudAngular.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {

        private readonly DataContext _context;

        public HeroController(DataContext context) 
        {
            _context = context;
        }
        [HttpGet]

        public async Task<ActionResult<List<Hero>>> GetHero()
        {
            return Ok(await _context.Heroes.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Hero>>> CreateHero(Hero hero)
        {
            _context.Heroes.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.Heroes.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<Hero>>> UpdateHero(Hero hero)
        {
            var dbHero = await _context.Heroes.FindAsync(hero.Id);
            if(dbHero == null)
            {
                return BadRequest("Heroi não encontrado.");
            }
            dbHero.HeroName = hero.HeroName;
            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.Place = hero.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.Heroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        
        public async Task<ActionResult<List<Hero>>> DeleteHero(Hero hero) 
        {
            var dbHero = await _context.Heroes.FindAsync(hero.Id);
            if(dbHero == null)
            {
                return BadRequest("Não existe herói com este ID... ");
            }
            _context.Heroes.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Heroes.ToListAsync());
        }
    }
}
