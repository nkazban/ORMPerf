using System;
using System.Collections.Generic;
using System.Text;

namespace ORMPerf.EF
{
    class MSSQLEFConnector : IDBConnector
    {
        public string Name => "MS SQL Entity Framework";

        public void AddRandomRows(int count)
        {
            using (var ctx = new MSSQLContext())
            {
                for (int i = 0; i < count; i++)
                {
                    ctx.SimpleModels.Add(SimpleModel.CreateRandom());
                    
                }
                ctx.SaveChanges();
            }
        }

        public void AddRandomRowsOneByOne(int count)
        {
            using (var ctx = new MSSQLContext())
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
            using (var ctx = new MSSQLContext())
            {
                foreach(var model in all)
                {
                    ctx.Remove(model);
                }
                ctx.SaveChanges();
            }
        }

        public IEnumerable<SimpleModel> ReadAll()
        {
            var result = new List<SimpleModel>();
            using(var context = new MSSQLContext())
            {
                result.AddRange(context.SimpleModels);
            }
            return result;
        }
    }
}
