using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prueba.Model.AggregateModels;

namespace Treebu.Crypto.Infrastructure.EntityConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasDefaultValueSql("nextval('user_sequence'::regclass)");

        builder.Property(e => e.Username)
            .HasColumnType("character varying")
            .HasColumnName("username");

        builder.Property(e => e.Pass)
            .HasColumnType("character varying")
            .HasColumnName("pass");

        builder.Property(e => e.CreatedDate)
            .ValueGeneratedOnAddOrUpdate()
            .HasColumnName("createddate");  
    }
}