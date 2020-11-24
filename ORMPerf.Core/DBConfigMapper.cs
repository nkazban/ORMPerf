using System.Collections.Generic;
using System.Data;

namespace ORMPerf.Core
{
    public enum DBType
    {
        SQLite,
        MSSQL,
        MySql
    }
    static class DBConfigMapper
    {
        private static Dictionary<DBType, Database> _dbs;

        static DBConfigMapper()
        {
            _dbs = new Dictionary<DBType, Database>();
            _dbs.Add(DBType.SQLite, new Database()
            {
                ConnectionString = "Data Source=sqlite.db",
            });

            _dbs.Add(DBType.MSSQL, new Database()
            {
                ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=ORMPerf;Trusted_Connection=True;MultipleActiveResultSets=true"
            });

            _dbs.Add(DBType.MySql, new Database()
            {
                ConnectionString = "server=localhost;UserId=ormperftest;Password=root;database=ORMPerf;"
            });
        }
        
        public static Database GetDBConfig(DBType type)
        {
            return _dbs[type];
        }
    }
}