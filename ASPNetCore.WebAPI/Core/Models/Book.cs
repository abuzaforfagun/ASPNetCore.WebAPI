using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCore.WebAPI.Core.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Categories { get; set; }

        public List<AuthorBook> AuthorsLink { get; set; }

        public Book()
        {
            AuthorsLink = new List<AuthorBook>();
        }
        
    }
}
