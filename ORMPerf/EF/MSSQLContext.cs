using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORMPerf.EF
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext()
        {
            Database.Migrate();
        }

        public DbSet<SimpleModel> Models { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DBConfigMapper.GetDBConfig(DBType.MSSQL).ConnectionString);
        }
    }
}
