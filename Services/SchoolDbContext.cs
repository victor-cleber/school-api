
using Microsoft.EntityFrameworkCore;
using SchoolApi.Models;

namespace SchoolApi.Services
{
  public class SchoolDbContext : DbContext
  {
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

    public DbSet<School> Schools { get; set; }
    }
}