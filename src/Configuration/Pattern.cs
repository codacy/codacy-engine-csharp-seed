using Newtonsoft.Json;

namespace Codacy.Engine.Seed.Configuration
{
    public sealed class Pattern : JsonModel
    {
        [JsonProperty(PropertyName = "patternId")]
        public string PatternId { get; set; }

        [JsonProperty(PropertyName = "parameters")]
        public Parameter[] Parameters { get; set; }
    }
}
