using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Codacy.Engine.Seed.Results
{
    /// <summary>
    ///     Codacy result model. This model represents a reported issue
    ///     on the tool wrapper.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class CodacyResult : JsonModel
    {
        /// <summary>
        ///     File name for the reported issue. This path is related to
        ///     the src/ folder inside the docker image.
        /// </summary>
        [JsonProperty(PropertyName = "filename")]
        public string Filename { get; set; }

        /// <summary>
        ///     Message reported by the tool describing the issue
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        ///     Pattern ID
        /// </summary>
        [JsonProperty(PropertyName = "patternId")]
        public string PatternId { get; set; }

        /// <summary>
        ///     Line in the source code where the issue occurs.
        /// </summary>
        [JsonProperty(PropertyName = "line")] public long? Line { get; set; }
    }
}
