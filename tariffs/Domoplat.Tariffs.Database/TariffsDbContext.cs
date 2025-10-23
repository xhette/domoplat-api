using Domoplat.Tariffs.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domoplat.Tariffs.Database;

/// <summary>
/// Контекст базы данных тарифов
/// </summary>
public class TariffsDbContext : DbContext {
    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanyTariff> CompanyTariffs { get; set; }
    public DbSet<Tariff> Tariffs { get; set; }
    public DbSet<UserTariff> UserTariffs { get; set; }

    public TariffsDbContext(DbContextOptions<TariffsDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        base.OnModelCreating(modelBuilder);
    }
}