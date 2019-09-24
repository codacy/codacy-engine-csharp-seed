using Newtonsoft.Json;

namespace Codacy.Engine.Seed.Results
{
    public sealed class CodacyResult : JsonModel
    {
        [JsonProperty(PropertyName = "filename")]
        public string Filename { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "patternId")]
        public string PatternId { get; set; }

        [JsonProperty(PropertyName = "line")] public long? Line { get; set; }
    }
}
