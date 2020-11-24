using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORMPerf.Core.EF
{
    class SQLiteEFConnector : IDBConnector
    {
        public string Name => "SQLite Entity Framework";
        public void AddRandomRows(int count)
        {
            using (var ctx = new SQLiteContext())
            {
                for (int i = 0; i < count; i++)
                {
                    ctx.SimpleModels.Add(SimpleModel.CreateRandom());

                }
                ctx.SaveChanges();
            }
        }
        public IEnumerable<SimpleModel> ReadAll()
        {
            SimpleModel[] result = null;
            using(var ctx = new SQLiteContext())
            {
                result = ctx.SimpleModels.ToArray();
            }
            return result;
        }

        public void AddRandomRowsOneByOne(int count)
        {
            using (var ctx = new SQLiteContext())
            {
                for (int i = 0; i < count; i++)
                {
                    ctx.SimpleModels.Add(SimpleModel.CreateRandom());
                    ctx.SaveChanges();
                }
                
            }
        }

        public void DeleteAllRows()
        {
        }
    }
}
