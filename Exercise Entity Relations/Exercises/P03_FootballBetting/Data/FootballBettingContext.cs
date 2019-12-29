using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public FootballBettingContext() : base()
        {

        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-B3I8JPR\\SQLEXPRESS;Database=FootballBettingDb;Integrated Security = true");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Team>()
                .HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Town)
                .WithMany(t => t.Teams)
                .HasForeignKey(t => t.TownId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.HomeTeam)
                .WithMany(c => c.HomeGames)
                .HasForeignKey(t => t.HomeTeamId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.AwayTeam)
                .WithMany(c => c.AwayGames)
                .HasForeignKey(t => t.AwayTeamId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Town>()
                .HasOne(g => g.Country)
                .WithMany(c => c.Towns)
                .HasForeignKey(t => t.CountryId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Player>()
                .HasOne(g => g.Team)
                .WithMany(c => c.Players)
                .HasForeignKey(t => t.TeamId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Player>()
                .HasOne(g => g.Position)
                .WithMany(c => c.Players)
                .HasForeignKey(t => t.PositionId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(ps => new { ps.GameId, ps.PlayerId });

            modelBuilder.Entity<PlayerStatistic>()
                .HasOne(g => g.Game)
                .WithMany(c => c.PlayerStatistics)
                .HasForeignKey(t => t.GameId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlayerStatistic>()
                .HasOne(g => g.Player)
                .WithMany(c => c.PlayerStatistics)
                .HasForeignKey(t => t.PlayerId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bet>()
                .HasOne(g => g.Game)
                .WithMany(c => c.Bets)
                .HasForeignKey(t => t.GameId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bet>()
                .HasOne(g => g.User)
                .WithMany(c => c.Bets)
                .HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.Restrict);
            ////////////////////            ⦁	A Team has one PrimaryKitColor and one SecondaryKitColor
            ////////////////////⦁	A Color has many PrimaryKitTeams and many SecondaryKitTeams
            ////////////////////⦁	A Team residents in one Town
            ////////////////////⦁	A Town can host several Teams
            //*/*/*/*/*/*/*/*/*/⦁	A Game has one HomeTeam and one AwayTeam and a Team can have many HomeGames and many AwayGames*/*/*/*/*/*/*/*/*/
            ////////////////////⦁	A Town can be placed in one Country and a Country can have many Towns
            ////////////////////⦁	A Player can play for one Team and one Team can have many Players
            ////////////////////⦁	A Player can play at one Position and one Position can be played by many Players
            ////////////////////⦁	One Player can play in many Games and in each Game, many Players take part(PlayerStatistics)
            ////////////////////⦁	Many Bets can be placed on one Game, but a Bet can be only on one Game
            //⦁	Each bet for given game must have Prediction result
            ////////////////////⦁	A Bet can be placed by only one User and one User can place many Bets

        }
    }
}
