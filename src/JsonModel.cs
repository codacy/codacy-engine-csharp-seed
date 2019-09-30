using Newtonsoft.Json;

namespace Codacy.Engine.Seed
{
    /// <summary>
    ///     JSON Model
    ///     This is an abstract class to implement convertion from
    ///     data models to JSON format.
    /// </summary>
    public abstract class JsonModel
    {
        /// <summary>
        ///     This serialize an object model to JSON format
        /// </summary>
        /// <param name="obj">object model to serialize</param>
        /// <param name="indented">indentation flag</param>
        /// <returns>serialized object as string in json format</returns>
        public static string ToString(object obj, bool indented)
        {
            return JsonConvert.SerializeObject(obj,
                indented ? Formatting.Indented : Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
        }

        /// <summary>
        ///     This serialize this object model to JSON format
        /// </summary>
        /// <param name="indented">indentation flag</param>
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
