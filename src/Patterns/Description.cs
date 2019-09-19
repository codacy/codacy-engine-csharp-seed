using Newtonsoft.Json;

namespace Codacy.Engine.Seed.Patterns
{
    public sealed class Description : JsonModel
    {
        [JsonProperty(PropertyName = "patternId")]
        public string PatternId { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string PatternDescription { get; set; }

        [JsonProperty(PropertyName = "parameters")]
        public DescriptionParameter[] Parameters { get; set; }

        [JsonProperty(PropertyName = "timeToFix")]
        public long? TimeToFix { get; set; }
    }
}
