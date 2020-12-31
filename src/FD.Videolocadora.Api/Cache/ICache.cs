namespace FD.Videolocadora.Api.Cache
{
    public interface ICache
    {
        void SetCache(string key, object value);
        object GetCache(string key);
    }
}
