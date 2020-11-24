using Microsoft.EntityFrameworkCore;

namespace ORMPerf.Core.EF
{
    public class SQLiteContext : DbContext
    {
        public SQLiteContext()
        {
            Database.Migrate();
        }
        public DbSet<SimpleModel> SimpleModels { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(DBConfigMapper.GetDBConfig(DBType.SQLite).ConnectionString);
        }
    }
}