using Microsoft.Data.SqlClient;
using Insight.Database;
using Microsoft.Extensions.Options;

namespace InsightDataBase;

public abstract class BaseRepository<T> where T : class
{
    //Для прямых вызовов
    private readonly SqlConnection _connection;
    //Для интерфейса Контекста
    protected readonly T Context;

    protected BaseRepository(IOptions<Settings> options)
    {
        _connection = new(options.Value.DbConnect);
        Insight.Database.Providers.MsSqlClient.SqlInsightDbProvider.RegisterProvider();
        Context = _connection.As<T>();
    }
}
