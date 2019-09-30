using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Codacy.Engine.Seed.Patterns
{
    /// <summary>
    ///     Pattern model used by patterns.json file.
    /// </summary>
    /// <see cref="CodacyPatterns"/>
    [ExcludeFromCodeCoverage]
    public sealed class Pattern : JsonModel
    {
        /// <summary>
        ///     Pattern ID
        /// </summary>
        [JsonProperty(PropertyName = "patternId")]
        public string PatternId { get; set; }

        /// <summary>
        ///     Codacy category
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "category")]
        public Category? Category { get; set; }

        /// <summary>
        ///     Codacy level
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "level")]
        public Level? Level { get; set; }

        /// <summary>
        ///     Parameters list
        /// </summary>
        [JsonProperty(PropertyName = "parameters")]
        public Parameter[] Parameters { get; set; }

    }
}
