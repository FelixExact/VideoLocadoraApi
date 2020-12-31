using Newtonsoft.Json;

namespace FD.Videolocadora.Domain.Helper
{
    public static class VideoLocadoraHelperToJson
    {
        public static string ToJson(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public static T FromJson<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
