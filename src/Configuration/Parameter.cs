using Newtonsoft.Json;

namespace Codacy.Engine.Seed.Configuration
{
    public sealed class Parameter
    {
        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "value")] public string Value { get; set; }
    }
}
