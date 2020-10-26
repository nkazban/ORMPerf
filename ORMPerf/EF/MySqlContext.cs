using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORMPerf.EF
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {
            Database.Migrate();
        }
        public DbSet<SimpleModel> Models { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(DBConfigMapper.GetDBConfig(DBType.MySql).ConnectionString);
        }
    }
}
