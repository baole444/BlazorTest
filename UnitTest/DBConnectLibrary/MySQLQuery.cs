using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectLibrary
{   
    // Make sure to update Interface when update this method.
    public class MySQLQuery : IMySQLQuery
    {
        // A generic method, takes in 2 generic values of T and U | U: any type

        // Load Data
        public async Task<List<T>> getDataQuery<T, U>(string sql, U parameters, string connectorString)
        {
            using (IDbConnection conn = new MySqlConnection(connectorString))
            {
                var rows = await conn.QueryAsync<T>(sql, parameters);

                // Allow breakpoint for debugs.
                return rows.ToList();
            }
        }

        // Save data
        public Task setDataQuery<T>(string sql, T parameters, string connectorString)
        {
            using (IDbConnection conn = new MySqlConnection(connectorString))
            {
                return conn.ExecuteAsync(sql, parameters);
            }
        }

    }
}
