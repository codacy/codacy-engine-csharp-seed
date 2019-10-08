using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Codacy.Engine.Seed.Patterns
{
    /// <summary>
    ///     Description model for CodacyDescription model.
    /// </summary>
    /// <see cref="CodacyDescription"/>
    [ExcludeFromCodeCoverage]
    public sealed class Description : JsonModel
    {
        /// <summary>
        ///     Pattern ID
        /// </summary>
        [JsonProperty(PropertyName = "patternId")]
        public string PatternId { get; set; }

        /// <summary>
        ///     Title of the pattern
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        ///     Description of the pattern
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string PatternDescription { get; set; }

        /// <summary>
        ///     Parameters description list for this pattern
        /// </summary>
        [JsonProperty(PropertyName = "parameters")]
        public DescriptionParameter[] Parameters { get; set; }

        /// <summary>
        ///     Average time to fix the issue reported
        /// </summary>
        [JsonProperty(PropertyName = "timeToFix")]
        public long? TimeToFix { get; set; }
    }
}
