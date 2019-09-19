using System.Collections.Generic;
using Newtonsoft.Json;

namespace Codacy.Engine.Seed.Patterns
{
    public sealed class CodacyDescription : List<Description>
    {
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
