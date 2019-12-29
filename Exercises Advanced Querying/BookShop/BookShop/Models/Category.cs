using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShop.Models
{
    public class Category
    {
        public Category()
        {
            this.CategoryBooks = new List<BookCategory>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        public virtual List<BookCategory> CategoryBooks { get; set; }
                                           //        CategoryId
                                           //o Name(up to 50 characters, unicode)
                                           //o CategoryBooks
    }
}
