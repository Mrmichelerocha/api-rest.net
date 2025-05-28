using System.Text.Json;
using System.Text.Json.Nodes;
using UserApi.Dtos;

namespace UserApi.Services;

public class PokeVibesService : IPokeVibesService
{
    private readonly HttpClient _httpClient;

    public PokeVibesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
    }

    public async Task<PokemonDto?> GetPokemonData(string name)
    {
        var response = await _httpClient.GetAsync($"pokemon/{name.ToLower()}");
        if (!response.IsSuccessStatusCode)
            return null;

        var content = await response.Content.ReadAsStringAsync();
        var json = JsonNode.Parse(content);

        if (json == null) return null;

        return new PokemonDto
        {
            Id = (int?)json["id"] ?? 0,
            Nome = (string?)json["name"] ?? "",
            Tipos = json["types"]?
                .AsArray()
                .Select(t => (string?)t["type"]?["name"] ?? "")
                .Where(n => !string.IsNullOrEmpty(n))
                .ToList() ?? new List<string>(),

            Foto = (string?)json["sprites"]?["front_default"] ?? ""
        };
    }
}
