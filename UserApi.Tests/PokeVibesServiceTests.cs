using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using UserApi.Services;
using Xunit;

namespace UserApi.Tests;

public class PokeVibesServiceTests
{
    [Fact]
    public async Task GetPokemonData_ReturnsExpectedResult()
    {
        // Arrange
        var mockHandler = new Mock<HttpMessageHandler>();

        var json = @"{
            ""id"": 25,
            ""name"": ""pikachu"",
            ""types"": [
                { ""type"": { ""name"": ""electric"" } }
            ],
            ""sprites"": {
                ""front_default"": ""https://pokeapi.co/media/sprites/pokemon/25.png""
            }
        }";

        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(json)
            });

        var client = new HttpClient(mockHandler.Object)
        {
            BaseAddress = new System.Uri("https://pokeapi.co/api/v2/")
        };

        var service = new PokeVibesService(client);

        // Act
        var result = await service.GetPokemonData("pikachu");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("pikachu", result!.Nome);
        Assert.Contains("electric", result.Tipos);
    }
}
