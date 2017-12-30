using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCore.WebAPI.Core.Models
{
    public class Author
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<AuthorBook> BooksLink { get; set; }

        public Author()
        {
            BooksLink = new List<AuthorBook>();
        }


    }
}
