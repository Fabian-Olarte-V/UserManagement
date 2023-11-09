using Microsoft.EntityFrameworkCore;
using Prueba.Model.AggregateModels;
using Treebu.Crypto.Infrastructure.EntityConfigurations;

namespace Prueba.Data
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)  : base(options) { }
        

        public DbSet<User> Users => Set<User>();
        public DbSet<Person> Persons => Set<Person>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PersonEntityTypeConfiguration());

            modelBuilder.HasSequence("user_sequence");
            modelBuilder.HasSequence("person_sequence");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
