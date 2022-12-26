using System.Collections.Generic;

namespace DataAccessLibrary.Databases
{
    public interface ISqlServerDataAccess
    {
        List<T> ReadData<T, U>(string sql,
                               U parameters,
                               string connectionStringName,
                               bool isStoredProcedure = false);
        void SaveData<T>(string sql,
                         T parameters,
                         string connectionStringName,
                         bool isStoredProcedure = false);
    }
}