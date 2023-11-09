using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prueba.Model.AggregateModels;

namespace Treebu.Crypto.Infrastructure.EntityConfigurations;

public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("persons");

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasDefaultValueSql("nextval('user_sequence'::regclass)");

        builder.Property(e => e.Name)
            .HasColumnType("character varying")
            .HasColumnName("firstname");

        builder.Property(e => e.LastName)
            .HasColumnType("character varying")
            .HasColumnName("lastname");

        builder.Property(e => e.NumIdentification)
            .HasColumnType("character varying")
            .HasColumnName("identificationnumber");

        builder.Property(e => e.Email)
            .HasColumnType("character varying")
            .HasColumnName("email");

        builder.Property(e => e.IdentificationType)
            .HasColumnType("character varying")
            .HasColumnName("identificationtype");

        builder.Property(e => e.CreatedDate)
            .ValueGeneratedOnAddOrUpdate()
            .HasColumnName("createddate");

        builder.Property(e => e.IdentificationAndType)
            .HasComputedColumnSql("IdentificationNumber || ' ' || IdentificationType")
            .HasColumnName("identificationandtype");

        builder.Property(e => e.FullName)
            .HasComputedColumnSql("Name || ' ' || LastName")
            .HasColumnName("fullname");

        builder.Property(e => e.UserId)
            .HasColumnName("userid");

        builder.HasOne<User>(p => p.User)
            .WithOne(u => u.Person)
            .HasForeignKey<Person>(p => p.UserId);
    }
}