using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyNotes.Models;

namespace MyNotes.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<Note>? Notes { get; set; }
    public DbSet<Product> Products { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
