using Microsoft.EntityFrameworkCore;

namespace Template.Models
{
  public class TemplateContext : DbContext
  {
    public DbSet<DaddyTemplate> DaddyTemplate { get; set; }
    public DbSet<BabyTemplatem> BabyTemplate { get; set; }

    public TemplateContext(DbContextOptions options) : base(options) { }
  }
}