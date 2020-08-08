using PizzaBox.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Storing
{
  public class PizzaBoxDbContext : DbContext
  {
    public DbSet<PizzaModel> Pizzas { get; set;} // create table
    public PizzaBoxDbContext(DbContextOptions options) : base(options) {} // dependency injection
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<PizzaModel>().HasKey(e => e.Id); // primary constraint
      builder.Entity<CrustModel>().HasKey(e => e.Id);
      builder.Entity<SizeModel>().HasKey(e => e.Id);
      builder.Entity<ToppingModel>().HasKey(e => e.Id);
    }
  }
}