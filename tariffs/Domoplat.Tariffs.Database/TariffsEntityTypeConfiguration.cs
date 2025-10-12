using Domoplat.Tariffs.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domoplat.Tariffs.Database;

public class TariffsEntityTypeConfiguration : 
IEntityTypeConfiguration<Tariff>,
IEntityTypeConfiguration<CompanyTariffs>,
IEntityTypeConfiguration<UserTariff>,
IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Tariff> builder)
    {
        throw new NotImplementedException();
    }

    public void Configure(EntityTypeBuilder<CompanyTariffs> builder)
    {
        throw new NotImplementedException();
    }

    public void Configure(EntityTypeBuilder<UserTariff> builder)
    {
        throw new NotImplementedException();
    }

    public void Configure(EntityTypeBuilder<Company> builder)
    {
        throw new NotImplementedException();
    }
}
