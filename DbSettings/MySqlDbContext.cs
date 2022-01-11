using Microsoft.EntityFrameworkCore;
using net5api.Entities;

namespace net5api.DbSettings{
    public class MySqlDbContext : DbContext {

        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options){
        }

        public DbSet<Item> Items {get;set;}

    }
}