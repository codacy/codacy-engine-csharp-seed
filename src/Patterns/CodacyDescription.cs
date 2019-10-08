using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Codacy.Engine.Seed.Patterns
{
    /// <summary>
    ///     Codacy description file model.
    ///     This represent a description file in documentation,
    ///     with a list of Description model in json format.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class CodacyDescription : List<Description>
    {
        /// <summary>
        ///     This serialize this object model to JSON format
        /// </summary>
        /// <param name="indented">indentation flag</param>
        /// <see cref="JsonModel.ToString(object, bool)"/>
        /// <returns>serialized object as string in json format</returns>
        public string ToString(bool indented)
        {
            return JsonModel.ToString(this, indented);
        }

        public override string ToString()
        {
            return this.ToString(false);
        }
    }
}
