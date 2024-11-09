using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet8.Data;
using SuperHeroAPI_DotNet8.DTO;
using SuperHeroAPI_DotNet8.Entities;
using SuperHeroAPI_DotNet8.Services;

namespace SuperHeroAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHeroDto>>> GetAllHeros()
        {
            return Ok(await _superHeroService.GetAllHerosAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHeroDto>> GetHero(int id)
        {
            var hero = await _superHeroService.GetHeroAsync(id);
            if (hero == null) return NotFound("Hero not found");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHeroDto>>> AddHero(SuperHeroDto heroDto)
        {
            return Ok(await _superHeroService.AddHeroAsync(heroDto));
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHeroDto>>> UpdateHero(SuperHeroDto heroDto)
        {
            var updatedHeros = await _superHeroService.UpdateHeroAsync(heroDto);
            if (updatedHeros == null) return NotFound("Hero not found");

            return Ok(updatedHeros);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHeroDto>>> DeleteHero(int id)
        {
            var remainingHeros = await _superHeroService.DeleteHeroAsync(id);
            if (remainingHeros == null) return NotFound("Hero not found");

            return Ok(remainingHeros);
        }

    }
}
