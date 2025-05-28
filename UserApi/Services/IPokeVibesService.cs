using UserApi.Dtos;

namespace UserApi.Services;

public interface IPokeVibesService
{
    Task<PokemonDto?> GetPokemonData(string name);
}
