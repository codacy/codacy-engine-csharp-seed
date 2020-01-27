using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Codacy.Engine.Seed.Patterns
{
    /// <summary>
    ///     Pattern model used by patterns.json file.
    /// </summary>
    /// <see cref="CodacyPatterns"/>
    public sealed class Pattern : JsonModel
    {
        private Pattern() { }
        public Pattern(
            string patternId,
            Level level,
            Category category,
            Subcategory? subcategory = null,
            Parameter[] parameters = null)
        {
            this.PatternId = patternId;
            this.Level = level;
            this.Category = category;
            if (subcategory.HasValue)
            {
                if (!Enum.IsDefined(typeof(Subcategory), subcategory)) throw new FormatException("Invalid subcategory");
                if (category != Category.Security) throw new FormatException("Security is the only category having subcategories");
            }
            this.Subcategory = subcategory;
            this.Parameters = parameters;
        }

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
        public Category Category { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "subcategory")]
        public Subcategory? Subcategory { get; set; }

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
