using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShop.Models
{
    public class Author
    {
        public Author()
        {
            this.Books = new List<Book>();
        }

        [Key]
        public int AuthorId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
                                           //        AuthorId
                                           //o FirstName(up to 50 characters, unicode, not required)
                                           //o LastName(up to 50 characters, unicode)
    }
}
