using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System.Text.Json;

namespace CarsWebAPI.App_Useing_Redis.Caching;

public class RedisCacheService(IConnectionMultiplexer connection) : IRedisCacheService
{
    private readonly IDatabase _database = connection.GetDatabase();

    public T? GetData<T>(string key)
    {
        var value = _database.StringGet(key);
        
        return value.IsNullOrEmpty 
            ? default 
            : JsonSerializer.Deserialize<T>(value!);

    }
    public void SetData<T>(string key, T data)
    {
        var jsonData = JsonSerializer.Serialize(data);

        _database.StringSet(key, jsonData,TimeSpan.FromSeconds(300));
    }
}
