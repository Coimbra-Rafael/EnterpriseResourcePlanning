using EnterpriseResourcePlanning.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseResourcePlanning.Api.Infrastructure.Context;

public class ErpDbContext : DbContext
{
    public ErpDbContext(DbContextOptions<ErpDbContext> options) : base(options) {}

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Enterprise> Enterprises { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserEnterprise> UserEnterprises { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ErpDbContext).Assembly);
    }
}