using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Api.Cache
{
    public interface ICache
    {
        void SetCache(string key, object value);
        object GetCache(string key);
    }
}
