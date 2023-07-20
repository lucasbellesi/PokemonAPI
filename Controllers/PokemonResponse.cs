using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PokemonAPI.Controllers
{
    public class PokemonResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("sprites")]
        public PokemonSprites Sprites { get; set; }
    }

    public class PokemonSprites
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }
    }
}
