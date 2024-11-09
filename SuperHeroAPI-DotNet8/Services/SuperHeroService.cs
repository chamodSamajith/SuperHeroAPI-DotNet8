using SuperHeroAPI_DotNet8.Data;
using SuperHeroAPI_DotNet8.DTO;
using SuperHeroAPI_DotNet8.Entities;
using Microsoft.EntityFrameworkCore;


namespace SuperHeroAPI_DotNet8.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHeroDto>> GetAllHerosAsync()
        {
            return await _context.SuperHeros
                .Select(hero => new SuperHeroDto
                {
                    Id = hero.Id,
                    Name = hero.Name,
                    FirstName = hero.FirstName,
                    LastName = hero.LastName,
                    Place = hero.Place
                }).ToListAsync();
        }

        public async Task<SuperHeroDto?> GetHeroAsync(int id)
        {
            var hero = await _context.SuperHeros.FindAsync(id);
            if (hero == null) return null;

            return new SuperHeroDto
            {
                Id = hero.Id,
                Name = hero.Name,
                FirstName = hero.FirstName,
                LastName = hero.LastName,
                Place = hero.Place
            };
        }

        public async Task<List<SuperHeroDto>> AddHeroAsync(SuperHeroDto heroDto)
        {
            var hero = new SuperHero
            {
                Name = heroDto.Name,
                FirstName = heroDto.FirstName,
                LastName = heroDto.LastName,
                Place = heroDto.Place
            };

            _context.SuperHeros.Add(hero);
            await _context.SaveChangesAsync();

            return await GetAllHerosAsync();
        }

        public async Task<List<SuperHeroDto>?> UpdateHeroAsync(SuperHeroDto heroDto)
        {
            var hero = await _context.SuperHeros.FindAsync(heroDto.Id);
            if (hero == null) return null;

            hero.Name = heroDto.Name;
            hero.FirstName = heroDto.FirstName;
            hero.LastName = heroDto.LastName;
            hero.Place = heroDto.Place;

            await _context.SaveChangesAsync();

            return await GetAllHerosAsync();
        }

        public async Task<List<SuperHeroDto>?> DeleteHeroAsync(int id)
        {
            var hero = await _context.SuperHeros.FindAsync(id);
            if (hero == null) return null;

            _context.SuperHeros.Remove(hero);
            await _context.SaveChangesAsync();

            return await GetAllHerosAsync();
        }
    }
}
