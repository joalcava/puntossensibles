using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers;

namespace WebApplication1;

public class PssContext : DbContext
{
    public PssContext(DbContextOptions<PssContext> options) : base(options)
    { }
    
    public DbSet<Topic> Topics { get; set; }
}