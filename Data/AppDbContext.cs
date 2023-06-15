using Microsoft.EntityFrameworkCore;
using ProjektZawody.Data.Extensions;
using ProjektZawody.Models;

namespace ProjektZawody.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(u => u.Name)
                .IsRequired();

            //mapowanie encji do tabel
            //tabela Score:
            modelBuilder.Entity<Score>()
                .ToTable("Scores");

            modelBuilder.Entity<Score>()
                .HasKey(x => new
                {
                    x.PlayerId,
                    x.CompetitionId
                });

            modelBuilder.Entity<Score>()
                .HasOne(x => x.Player)
                .WithMany(x => x.Scores)
                .HasForeignKey(x => x.PlayerId);

            modelBuilder.Entity<Score>()
                .HasOne(x => x.Competition)
                .WithMany(x => x.Scores)
                .HasForeignKey(x => x.CompetitionId);

            //tabela Players
            modelBuilder.Entity<Player>()
                .ToTable("Players");
            modelBuilder.Entity<Player>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Player>()
                .Property(p => p.Id)
                .UseIdentityColumn(seed: 1, increment: 1);


            //tabela Competitions
            modelBuilder.Entity<Competition>()
                .ToTable("Competitions");
            modelBuilder.Entity<Competition>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Competition>()
                .Property(p => p.Id)
                .UseIdentityColumn(seed: 1, increment: 1);


            modelBuilder.Seed();
        }
    }
}
