using System;
using System.Collections.Generic;
using System.Text;

namespace ORMPerf.EF
{
    class MySqlEFConnector : IDBConnector
    {
        public string Name => "MySql Entity Framework";
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
            using (var ctx = new MySqlContext())
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
            using(var ctx = new MySqlContext())
            {
                //ctx.Models.
            }
        }

        public IEnumerable<SimpleModel> ReadAll()
        {
            var result = new List<SimpleModel>();
            using (var context = new MySqlContext())
            {
                result.AddRange(context.SimpleModels);
            }
            return result;
        }
    }
}
