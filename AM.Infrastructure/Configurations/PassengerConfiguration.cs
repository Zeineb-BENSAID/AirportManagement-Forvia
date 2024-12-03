using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations;

public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger> builder)
    {
        //La propriété FirstName a une longueur maximale de 30 et le nom de la colonne correspondante à cette propriété dans la base de données doit être PassFirstName
        //La propriété LastName est obligatoire et le nom de la colonne correspondante à cette propriété dans la base de données doit être PassLastName

        builder.OwnsOne(p => p.FullName, fn =>
        {
            fn.Property(fn => fn.FirstName).HasMaxLength(30).HasColumnName("PassFirstName");
            fn.Property(fn => fn.LastName).HasColumnName("PassLastName").IsRequired();
        }

        );
    }
}
