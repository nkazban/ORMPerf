using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORMPerf.Core.ADO
{
    class MySqlADOConnector : IDBConnector
    {
        Database _db;

        public MySqlADOConnector()
        {
            _db = DBConfigMapper.GetDBConfig(DBType.MySql);
        }

        public string Name => "MySql ADO";

        public void AddRandomRows(int count)
        {
            throw new NotImplementedException();
        }

        public void AddRandomRowsOneByOne(int count)
        {
            using(var conn = new MySqlConnection(_db.ConnectionString))
            {
                conn.Open();

                for (int i = 0; i < count; i++)
                {
                    var command = conn.CreateCommand();
                    command.CommandText = @"INSERT INTO SimpleModels (Name, Birth, About) VALUES (@Name, @Birth, @About)";

                    var p1 = new MySqlParameter("@Name", $"{i}");
                    command.Parameters.Add(p1);

                    var p2 = new MySqlParameter("@Birth", DateTime.Now);
                    command.Parameters.Add(p2);

                    var p3 = new MySqlParameter("@About", "");
                    command.Parameters.Add(p3);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAllRows()
        {
            using (var conn = new MySqlConnection(_db.ConnectionString))
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
            using (var conn = new MySqlConnection(_db.ConnectionString))
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
