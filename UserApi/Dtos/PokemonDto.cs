namespace UserApi.Dtos;

public class PokemonDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public List<string> Tipos { get; set; } = new();
    public string Foto { get; set; } = string.Empty;
}
