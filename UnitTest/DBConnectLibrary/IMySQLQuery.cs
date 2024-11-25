

namespace DBConnectLibrary
{
    public interface IMySQLQuery
    {
        Task<List<T>> getDataQuery<T, U>(string sql, U parameters, string connectorString);
        Task setDataQuery<T>(string sql, T parameters, string connectorString);
    }
}