using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnect
{
    public class MySQLConnect : IMySQLConnect
    {
        public async Task<List<T>> getQueryData<T, U>(string sql, U parameters, string connectorString)
        {
            using (IDbConnection conn = new MySqlConnection(connectorString))
            {
                var rows = await conn.QueryAsync<T>(sql, parameters);

                return rows.ToList();
            }
        }

        public Task setQueryData<T>(string sql, T parameters, string connectorString)
        {
            using (IDbConnection conn = new MySqlConnection(connectorString))
            {
                return conn.ExecuteAsync(sql, parameters);
            }
        }
    }
}
