﻿using Microsoft.EntityFrameworkCore;

namespace ORMPerf.EF
{
    public class SQLiteContext : DbContext
    {
        public SQLiteContext()
        {
            Database.Migrate();
        }
        public DbSet<SimpleModel> Models { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(DBConfigMapper.GetDBConfig(DBType.SQLite).ConnectionString);
        }
    }
}