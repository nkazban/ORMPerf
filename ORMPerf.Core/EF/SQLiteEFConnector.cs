using System.Collections.Generic;
using System.Linq;

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
            var all = ReadAll();
            using (var ctx = new SQLiteContext())
            {
                foreach (var model in all)
                {
                    ctx.Remove(model);
                }
                ctx.SaveChanges();
            }
        }
    }
}
