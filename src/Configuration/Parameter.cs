using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Codacy.Engine.Seed.Configuration
{
    /// <summary>
    ///     Parameter model for codacy configuration file.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class Parameter : JsonModel
    {
        /// <summary>
        ///     Name of the pattern parameter
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     Specified value of the pattern parameter
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}
