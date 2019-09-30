using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Codacy.Engine.Seed.Patterns
{
    /// <summary>
    ///     Description of a specific parameter in Codacy description file.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class DescriptionParameter : JsonModel
    {
        /// <summary>
        ///     Name of the pattern parameter
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     Description for this parameter
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
