using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DataAccessLibrary.Databases
{
    public class SqlServerDataAccess : ISqlServerDataAccess
    {
        private readonly IConfiguration _config;

        public SqlServerDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public List<T> ReadData<T, U>(string sql,
                                     U parameters,
                                     string connectionStringName,
                                     bool isStoredProcedure = false)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            CommandType commandType = CommandType.Text;

            if (isStoredProcedure)
            {
                commandType = CommandType.StoredProcedure;
            }

            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                List<T> rows = dbConnection.Query<T>(sql, parameters, commandType: commandType).ToList();

                return rows;
            }
        }

        public void SaveData<T>(string sql,
                                T parameters,
                                string connectionStringName,
                                bool isStoredProcedure = false)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            CommandType commandType = CommandType.Text;

            if (isStoredProcedure)
            {
                commandType = CommandType.StoredProcedure;
            }

            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Execute(sql, parameters, commandType: commandType);
            }
        }


    }
}
