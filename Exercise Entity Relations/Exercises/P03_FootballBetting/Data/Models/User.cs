using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class User
    {
        public User()
        {
            this.Bets = new List<Bet>();
        }

        [Key]
        public int UserId { get; set; }

        [Required]
        [Column("Username", TypeName = "nvarchar(50)")]
        public string Username { get; set; }

        [Required]
        [Column("Password", TypeName = "nvarchar(50)")]
        public string Password { get; set; }

        [Required]
        [Column("Email", TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Required]
        [Column("Name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        public decimal Balance { get; set; }

        public ICollection<Bet> Bets { get; set; }
    }
}
