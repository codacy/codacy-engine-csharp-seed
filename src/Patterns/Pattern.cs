using System.Diagnostics.CodeAnalysis;
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
            if(subcategory.HasValue) {
                switch(subcategory.Value) {
                    case Patterns.Subcategory.Injection:
                    case Patterns.Subcategory.BrokenAuth:
                    case Patterns.Subcategory.SensitiveData:
                    case Patterns.Subcategory.XXE:
                    case Patterns.Subcategory.BrokenAccess:
                    case Patterns.Subcategory.Misconfiguration:
                    case Patterns.Subcategory.XSS:
                    case Patterns.Subcategory.BadDeserialization:
                    case Patterns.Subcategory.VulnerableComponent:
                    case Patterns.Subcategory.NoLogging:
                        if(category != Category.Security)
						{
                            goto default;
                        }
						break;

                    default:
						throw new System.FormatException("Invalid subcategory!");

				}
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
