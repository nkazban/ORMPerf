using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORMPerf.EF
{
    class SQLiteEFConnector : IDBConnector
    {
        Database _db;

        public IEnumerable<SimpleModel> ReadAll()
        {
            SimpleModel[] result = null;
            using(var ctx = new SQLiteContext())
            {
                result = ctx.Models.ToArray();
            }
            return result;
        }

        public void AddRandomRows(int count)
        {
            using (var ctx = new SQLiteContext())
            {
                for (int i = 0; i < count; i++)
                {
                    var mdl = new SimpleModel();
                    mdl.Id = Guid.NewGuid();
                    mdl.Name = $"{i}";
                    mdl.Birth = DateTime.Now;
                    mdl.About = "";
                    ctx.Models.Add(mdl);
                }
                ctx.SaveChanges();
            }
        }

        public void Connect()
        {
            _db = DBConfigMapper.GetDBConfig(DBType.SQLite);
        }

        public void DeleteAllRows()
        {
        }

        public void Disconnect()
        {
        }
    }
}
