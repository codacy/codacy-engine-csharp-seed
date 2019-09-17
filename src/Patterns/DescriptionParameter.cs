using Newtonsoft.Json;

namespace Codacy.Engine.Seed.Patterns
{
    public sealed class DescriptionParameter
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
