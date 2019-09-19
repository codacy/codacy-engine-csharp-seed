using System.Collections.Generic;
using Newtonsoft.Json;

namespace Codacy.Engine.Seed.Patterns
{
    public sealed class CodacyPatterns : JsonModel
    {
        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        [JsonProperty(PropertyName = "patterns")]
        public List<Pattern> Patterns { get; set; }
    }
}
