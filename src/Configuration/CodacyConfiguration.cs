using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Codacy.Engine.Seed.Configuration
{
    /// <summary>
    ///     Codacy configuration file model.
    ///     This represents a codacy configuration file, in json.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class CodacyConfiguration : JsonModel
    {
        /// <summary>
        ///     List of files to analyze
        /// </summary>
        [JsonProperty(PropertyName = "files")]
        public string[] Files { get; set; }

        /// <summary>
        ///     Tools list with all patterns for each tool
        /// </summary>
        [JsonProperty(PropertyName = "tools")]
        public Tool[] Tools { get; set; }
    }
}
