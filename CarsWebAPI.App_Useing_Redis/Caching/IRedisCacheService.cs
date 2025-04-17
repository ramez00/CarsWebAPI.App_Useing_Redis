namespace CarsWebAPI.App_Useing_Redis.Caching;

public interface IRedisCacheService
{
    T? GetData<T>(string key);
    void SetData<T>(string key, T data);
}
