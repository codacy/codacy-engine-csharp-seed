using Newtonsoft.Json;

namespace Codacy.Engine.Seed.Configuration
{
    public sealed class Tool
    {
        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "patterns")]
        public Pattern[] Patterns { get; set; }
    }
}
