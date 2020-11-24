using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORMPerf.Core.EF
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            Database.Migrate();
        }

        public DbSet<SimpleModel> SimpleModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DBConfigMapper.GetDBConfig(DBType.MSSQL).ConnectionString);
        }
    }
}
