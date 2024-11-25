
namespace DBConnect
{
    public interface IMySQLConnect
    {
        Task<List<T>> getQueryData<T, U>(string sql, U parameters, string connectorString);
        Task setQueryData<T>(string sql, T parameters, string connectorString);
    }
}