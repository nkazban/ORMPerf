using System;
using System.Collections.Generic;
using System.Text;

namespace ORMPerf.EF
{
    class MSSQLEFConnector : IDBConnector
    {
        public void AddRandomRows(int count)
        {
            using (var ctx = new MSSQLContext())
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
        }

        public void DeleteAllRows()
        {
        }

        public void Disconnect()
        {
        }

        public IEnumerable<SimpleModel> ReadAll()
        {
            var result = new List<SimpleModel>();
            using(var context = new MSSQLContext())
            {
                result.AddRange(context.Models);
            }
            return result;
        }
    }
}
