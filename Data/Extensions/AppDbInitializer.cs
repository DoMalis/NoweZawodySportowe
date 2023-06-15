using Microsoft.EntityFrameworkCore;
using ProjektZawody.Data.Enums;
using ProjektZawody.Models;

namespace ProjektZawody.Data.Extensions
{
    public static class AppDbInitializer
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {

            //Competition
            modelBuilder.Entity<Competition>()
            .HasData(new Competition()
            {
                Id = -2,
                Name = "Siatkowka",
                MaxAge = 10,
                MinAge = 11,
                CompetitionStatus = CompetitionStatus.Finished
            },
            new Competition()
            {
                Id = -1,
                Name = "Nozna",
                MaxAge = 10,
                MinAge = 11,
                CompetitionStatus = CompetitionStatus.Notstarted
            });

            //Player

            modelBuilder.Entity<Player>()
                .HasData(new Player()
                {
                    Id = -1,
                    FirstName = "Darek",
                    LastName = "Odkrywca ",
                    Age = 10
                },
                new Player()
                {
                    Id = -2,
                    FirstName = "Dagmar",
                    LastName = "Poszukiwacz",
                    Age = 15
                },
                new Player()
                {
                    Id = -3,
                    FirstName = "Dorian",
                    LastName = "Nawigator",
                    Age = 12

                });
            //Score
            modelBuilder.Entity<Score>()
                .HasData(
                new Score()
                {
                    CompetitionId =  -1,
                    PlayerId = -3
                },
                new Score()
                {
                    CompetitionId = -1,
                    PlayerId = -1
                },
                new Score()
                {
                    CompetitionId = -1,
                    PlayerId = -2,
                    Points=5
                },
                new Score()
                {
                    CompetitionId = -2,
                    PlayerId = -1
                },
                new Score()
                {
                    CompetitionId = -2,
                    PlayerId = -2
                });

           //Role
           /* modelBuilder.Entity<Role>()
                .HasData(
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Judge"
                },
                new Role()
                {
                    Name = "Admin"
                });*/
        }
    }
}
