using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Codacy.Engine.Seed.Patterns
{
    /// <summary>
    ///     Codacy patterns file model.
    ///     This represents the patterns.json file in documentation.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class CodacyPatterns : JsonModel
    {
        /// <summary>
        ///     Name of the tool
        /// </summary>
        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        /// <summary>
        ///     Version of the used tool
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        /// <summary>
        ///     List of patterns
        /// </summary>
        [JsonProperty(PropertyName = "patterns")]
        public List<Pattern> Patterns { get; set; }
    }
}
