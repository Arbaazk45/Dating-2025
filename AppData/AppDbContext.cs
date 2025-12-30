

using API.Intities;
using Microsoft.EntityFrameworkCore;

namespace API.AppData;
    public class AppDbContext(DbContextOptions options) : DbContext(options)
 {
    public DbSet<AppUser> user { get; set; }
 }

