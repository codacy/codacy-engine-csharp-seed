using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Codacy.Engine.Seed.Configuration
{
    /// <summary>
    ///     Pattern model for codacy configuration file.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class Pattern : JsonModel
    {
        /// <summary>
        ///     Pattern ID
        /// </summary>
        [JsonProperty(PropertyName = "patternId")]
        public string PatternId { get; set; }

        /// <summary>
        ///     List if pattern parameters
        /// </summary>
        [JsonProperty(PropertyName = "parameters")]
        public Parameter[] Parameters { get; set; }
    }
}
