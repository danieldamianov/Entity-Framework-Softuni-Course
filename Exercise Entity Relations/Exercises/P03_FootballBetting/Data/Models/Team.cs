using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        public Team()
        {
            this.Players = new List<Player>();
            this.HomeGames = new List<Game>();
            this.AwayGames = new List<Game>();
        }

        [Key]
        public int TeamId { get; set; }

        [Required]
        [Column("Name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Required]
        [Column("LogoUrl", TypeName = "varchar(150)")]
        public string LogoUrl { get; set; }

        [Required]
        [Column("Initials", TypeName = "char(3)")]
        public string Initials { get; set; }

        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor { get; set; }

        public int SecondaryKitColorId { get; set; }
        public Color SecondaryKitColor { get; set; }

        public int TownId { get; set; }
        public Town Town { get; set; }

        public ICollection<Player> Players { get; set; }

        public ICollection<Game> HomeGames { get; set; }

        public ICollection<Game> AwayGames { get; set; }
    }
}
