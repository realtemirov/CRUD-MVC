using Microsoft.EntityFrameworkCore;
using youtubelearn.Models;

namespace youtubelearn.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }
}