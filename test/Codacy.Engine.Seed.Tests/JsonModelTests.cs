using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Xunit;

namespace Codacy.Engine.Seed.Tests
{
    public class JsonModelTests
    {

        private class TestModel : JsonModel
        {
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "number")]
            public long? Number { get; set; }

            [JsonProperty(PropertyName = "names")]
            public List<string> Names { get; set; }

            public override bool Equals(object obj)
            {
                if (this == obj)
                {
                    return true;
                } else if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }
                else
                {
                    var r = (TestModel) obj;

                    return Name == r.Name && Number == r.Number && (Names?.SequenceEqual(r.Names) ?? r.Names == null);
                }
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hash = (int) 2166136261;
                    hash = (hash * 16777619) ^ Number.GetHashCode();
                    hash = (hash * 16777619) ^ (Names != null ? Names.GetHashCode() : 0);
                    return (hash * 16777619) ^ (Name != null ? Name.GetHashCode() : 0);
                }
            }
        }

        [Fact]
        void JsonStringTests()
        {
            TestModel testModel = new TestModel
            {
                Name = "foo",
                Number = 42,
                Names = new[] {"foo", "bar", "foobar"}.ToList()
            };

            string testModelJson = "{\"name\":\"foo\",\"number\":42,\"names\":[\"foo\",\"bar\",\"foobar\"]}";

            Assert.Equal(JsonConvert.DeserializeObject<TestModel>(testModelJson), testModel);
            Assert.Equal(testModelJson, testModel.ToString());

            testModel = new TestModel
            {
                Name = "foo"
            };

            testModelJson = "{\"name\":\"foo\"}";

            Assert.Equal(JsonConvert.DeserializeObject<TestModel>(testModelJson), testModel);
            Assert.Equal(testModelJson, testModel.ToString());
        }
    }
}
