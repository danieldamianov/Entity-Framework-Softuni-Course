using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Country
    {
        public Country()
        {
            this.Towns = new List<Town>();
        }

        [Key]
        public int CountryId { get; set; }
        
        [Column("Name", TypeName = "varchar(40)")]
        [Required]
        public string Name { get; set; }

        public ICollection<Town> Towns { get; set; }
    }
}
