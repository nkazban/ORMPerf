using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORMPerf.Core.EF
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {
            Database.Migrate();
        }
        public DbSet<SimpleModel> SimpleModels { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(DBConfigMapper.GetDBConfig(DBType.MySql).ConnectionString);
        }
    }
}
