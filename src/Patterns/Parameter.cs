using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Codacy.Engine.Seed.Patterns
{
    /// <summary>
    ///     Parameter model for a pattern in Codacy patterns model.
    /// </summary>
    /// <see cref="CodacyPatterns"/>
    /// <see cref="Pattern"/>
    [ExcludeFromCodeCoverage]
    public sealed class Parameter : JsonModel
    {
        /// <summary>
        ///     Name of the parameter
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     Default value for the parameter
        /// </summary>
        [JsonProperty(PropertyName = "default")]
        public string Default { get; set; }
    }
}
