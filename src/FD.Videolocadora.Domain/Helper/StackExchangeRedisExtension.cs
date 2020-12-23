using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Domain.Helper
{
    public static class StackExchangeRedisExtension
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
