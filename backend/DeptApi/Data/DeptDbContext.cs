
using DeptApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DeptApi.Data
{
    public class DeptDbContext : DbContext
    {
        public DeptDbContext(DbContextOptions<DeptDbContext> options) : base(options)
        {
        }

        public DbSet<Dept> Depts { get; set; }
        public DbSet<Manager> Managers { get; set; }
    }
}
