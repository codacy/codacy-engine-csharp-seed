using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Codacy.Engine.Seed.Patterns
{
    public sealed class Pattern : JsonModel
    {
        [JsonProperty(PropertyName = "patternId")]
        public string PatternId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "category")]
        public Category? Category { get; set; }

        [JsonProperty(PropertyName = "parameters")]
        public Parameter[] Parameters { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "level")]
        public Level? Level { get; set; }
    }
}
