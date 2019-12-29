using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class User
    {
        public User(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            this.PaymentMethods = new List<PaymentMethod>();
        }

        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(80)]
        [Column(TypeName = "varchar(80)")]
        public string Email { get; set; }

        [Required]
        [MaxLength(25)]
        [Column(TypeName = "varchar(25)")]
        public string Password { get; set; }

        public virtual ICollection<PaymentMethod> PaymentMethods { get; set; }

        //        o FirstName(up to 50 characters, unicode)
        //o LastName(up to 50 characters, unicode)
        //o Email(up to 80 characters, non-unicode)
        //o Password(up to 25 characters, non-unicode)
    }
}
