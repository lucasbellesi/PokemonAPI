using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly HttpClient httpClient;

        public PokemonController()
        {
            httpClient = new HttpClient();
        }

        [HttpGet("{pokemonName}")]
        public async Task<IActionResult> Get(string pokemonName)
        {
            var apiUrl = $"https://pokeapi.co/api/v2/pokemon/{pokemonName.ToLower()}";
            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var pokemonResponse = await response.Content.ReadFromJsonAsync<PokemonResponse>();

                var model = new PokemonViewModel
                {
                    Name = pokemonResponse.Name,
                    Weight = pokemonResponse.Weight,
                    Height = pokemonResponse.Height,
                    ImageUrl = pokemonResponse.Sprites.FrontDefault
                };

                return Ok(model);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
