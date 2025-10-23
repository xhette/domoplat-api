using Domoplat.Tariffs.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domoplat.Tariffs.Database;

public class TariffsEntityTypeConfiguration : 
IEntityTypeConfiguration<Tariff>,
IEntityTypeConfiguration<CompanyTariff>,
IEntityTypeConfiguration<UserTariff>,
IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Tariff> builder)
    {
        builder.HasKey(x => x.Id);
    }

    public void Configure(EntityTypeBuilder<CompanyTariff> builder)
    {
        builder.HasKey(x => x.Id);

        builder
        .HasIndex(x => new { x.CompanyId, x.TariffId })
        .IsUnique();

        builder
        .HasOne(x => x.Company)
        .WithMany(x => x.CompanyTariffs)
        .HasForeignKey(x => x.CompanyId);

        builder
        .HasOne(x => x.Tariff)
        .WithMany(x => x.CompanyTariffs)
        .HasForeignKey(x => x.TariffId);
    }

    public void Configure(EntityTypeBuilder<UserTariff> builder)
    {
        builder.HasKey(x => x.Id);

        builder
        .HasIndex(x => new { x.UserId, x.CompanyTariffId })
        .IsUnique();

        builder
        .HasOne(x => x.CompanyTariff)
        .WithMany(x => x.UserTariffs)
        .HasForeignKey(x => x.CompanyTariffId);
    }

    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
