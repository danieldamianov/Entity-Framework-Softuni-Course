using BookShop.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShop.Models
{
    public class Book
    {
        public Book()
        {
            this.BookCategories = new List<BookCategory>();
        }

        [Key]
        public int BookId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        [Required]
        public string Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int Copies { get; set; }

        public decimal Price { get; set; }

        public EditionType EditionType { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public virtual List<BookCategory> BookCategories { get; set; }


        //        BookId
        //o Title(up to 50 characters, unicode)
        //o Description(up to 1000 characters, unicode)
        //o ReleaseDate(not required)
        //o Copies(an integer)
        //o Price
        //o EditionType – enum (Normal, Promo, Gold)

        //© Software University Foundation.This work is licensed under the CC-BY-NC-SA license.
        //Follow us: Page 6 of 6


        //o AgeRestriction – enum (Minor, Teen, Adult)
        //o Author
        //o BookCategories
    }
}
