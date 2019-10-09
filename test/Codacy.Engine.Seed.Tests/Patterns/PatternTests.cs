using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Xunit;

using Codacy.Engine.Seed.Patterns;

namespace Codacy.Engine.Seed.Tests.Patterns
{
	public class PatternTests
    {
        [Fact]
        void SubcategoryTests()
        {
            //shoudn't throw exception
            Pattern patternSuccess = new Pattern("foo", Level.Warning, Category.Security, Subcategory.XSS);
        }
    }
}
