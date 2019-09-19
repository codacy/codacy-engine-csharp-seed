using Newtonsoft.Json;

namespace Codacy.Engine.Seed
{
    public class JsonModel
    {
        public static string ToString(object obj, bool indented)
        {
            return JsonConvert.SerializeObject(obj,
                indented ? Formatting.Indented : Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
        }

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
