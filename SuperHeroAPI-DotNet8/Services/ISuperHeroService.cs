using SuperHeroAPI_DotNet8.DTO;

namespace SuperHeroAPI_DotNet8.Services
{
    public interface ISuperHeroService
    {
        Task<List<SuperHeroDto>> GetAllHerosAsync();
        Task<SuperHeroDto?> GetHeroAsync(int id);
        Task<List<SuperHeroDto>> AddHeroAsync(SuperHeroDto heroDto);
        Task<List<SuperHeroDto>?> UpdateHeroAsync(SuperHeroDto heroDto);
        Task<List<SuperHeroDto>?> DeleteHeroAsync(int id);
    }
}
