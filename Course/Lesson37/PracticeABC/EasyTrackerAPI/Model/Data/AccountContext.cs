using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class AccountContext : IdentityDbContext<ApplicationUser>
{
    public AccountContext(DbContextOptions<AccountContext> options)
        : base(options)
    {
        Console.WriteLine("Account context created");
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(user => user.ID);
    }
}