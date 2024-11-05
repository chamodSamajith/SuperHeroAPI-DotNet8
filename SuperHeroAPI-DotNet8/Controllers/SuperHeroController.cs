using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet8.Data;
using SuperHeroAPI_DotNet8.Entities;

namespace SuperHeroAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            var heros = await _context.SuperHeros.ToListAsync();

            return Ok(heros);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await _context.SuperHeros.FindAsync(id);
            if(hero is null) 
                return BadRequest("Hero not found");

            return Ok(hero);

        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.SuperHeros.Add(hero);
            await _context.SaveChangesAsync();


            return Ok(await _context.SuperHeros.ToListAsync());

        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero hero)
        {
            var dbHero = await _context.SuperHeros.FindAsync(hero.Id);
            if (dbHero is null)
                return BadRequest("Hero not found");

            dbHero.Name = hero.Name;
            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.Place = hero.Place;

            await _context.SaveChangesAsync();


            return Ok(await _context.SuperHeros.ToListAsync());

        }

        [HttpDelete]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var dbHero = await _context.SuperHeros.FindAsync(id);
            if (dbHero is null)
                return BadRequest("Hero not found");

            _context.SuperHeros.Remove(dbHero);

            await _context.SaveChangesAsync();


            return Ok(await _context.SuperHeros.ToListAsync());

        }

    }
}
