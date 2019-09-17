using Newtonsoft.Json;

namespace Codacy.Engine.Seed.Patterns
{
    public sealed class Parameter
    {
        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "default")]
        public string Default { get; set; }
    }
}
