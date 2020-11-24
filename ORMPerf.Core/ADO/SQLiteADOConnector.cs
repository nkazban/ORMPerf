using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORMPerf.Core.ADO
{
    class SQLiteADOConnector : IDBConnector
    {
        Database _db;

        public SQLiteADOConnector()
        {
            _db = DBConfigMapper.GetDBConfig(DBType.SQLite);
        }

        public string Name => "SQLite ADO";

        public void AddRandomRows(int count)
        {
            throw new NotImplementedException();
        }

        public void AddRandomRowsOneByOne(int count)
        {
            using (var conn = new SqliteConnection(_db.ConnectionString))
            {
                conn.Open();

                for (int i = 0; i < count; i++)
                {
                    var command = conn.CreateCommand();
                    command.CommandText = @"INSERT INTO SimpleModels (Name, Birth, About) VALUES (@Name, @Birth, @About)";

                    var p1 = new SqliteParameter("@Name", $"{i}");
                    command.Parameters.Add(p1);

                    var p2 = new SqliteParameter("@Birth", DateTime.Now);
                    command.Parameters.Add(p2);

                    var p3 = new SqliteParameter("@About", "");
                    command.Parameters.Add(p3);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAllRows()
        {
            using (var conn = new SqliteConnection(_db.ConnectionString))
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "DELETE FROM SimpleModels";
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<SimpleModel> ReadAll()
        {
            var result = new List<SimpleModel>();
            using(var conn = new SqliteConnection(_db.ConnectionString))
            {
                conn.Open();

                var command = conn.CreateCommand();
                command.CommandText = @"SELECT * FROM SimpleModels";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.ReadModel());
                    }
                }
            }
            return result;
        }
    }
}
