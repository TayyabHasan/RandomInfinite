
using Microsoft.EntityFrameworkCore;
using RI.api.Models;

namespace RI.api.Data
{
    public class DataContext: DbContext
    {
        //DI Injection in code  
        public DataContext(DbContextOptions<DataContext> options):base(options){ }

        public DbSet<Video> Videos { get; set; }

    }
}