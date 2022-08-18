using Newtonsoft.Json;
using System.Text;

namespace BoxberryClient
{
    static class Extensions
    {
        private static readonly string _mediType = "application/json";
        private static readonly JsonSerializerSettings _serializeSettings = new()
        {
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore,
        };

        public static string ToJSON(this object @this) => JsonConvert.SerializeObject(@this, _serializeSettings);

        public static StringContent ToStringContent(this object @this) => new(@this.ToJSON(), Encoding.UTF8, _mediType);

        public static T Deserialize<T>(this string @this) => JsonConvert.DeserializeObject<T>(@this);

        public static T Deserialize<T>(this string @this, JsonSerializerSettings serializerSettings) => JsonConvert.DeserializeObject<T>(@this, serializerSettings);

        public static bool IsEmpty(this string @this) => string.IsNullOrEmpty(@this?.Trim());
    }
}
