using Microsoft.AspNetCore.Mvc;
using UserApi.Services;

namespace UserApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokemonController : ControllerBase
{
    private readonly IPokeVibesService _pokeService;

    public PokemonController(IPokeVibesService pokeService)
    {
        _pokeService = pokeService;
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetPokemon(string name)
    {
        var result = await _pokeService.GetPokemonData(name);
        if (result == null)
            return NotFound(new { message = "Pokémon não encontrado" });

        return Ok(result);
    }
}
