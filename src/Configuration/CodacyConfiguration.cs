using Newtonsoft.Json;

namespace Codacy.Engine.Seed.Configuration
{
    public sealed class CodacyConfiguration : JsonModel
    {
        [JsonProperty(PropertyName = "files")]
        public string[] Files { get; set; }

        [JsonProperty(PropertyName = "tools")]
        public Tool[] Tools { get; set; }
    }
}
