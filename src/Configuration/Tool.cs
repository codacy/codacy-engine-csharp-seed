using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Codacy.Engine.Seed.Configuration
{
    /// <summary>
    ///     Tool model for codacy configuration file.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class Tool : JsonModel
    {
        /// <summary>
        ///     Name of the tool (described on '/docs/patterns.json' tool)
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     Patterns list
        /// </summary>
        [JsonProperty(PropertyName = "patterns")]
        public Pattern[] Patterns { get; set; }
    }
}
