using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCore.WebAPI.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> BooksLink { get; set; }
        public Category()
        {
            
        }
    }
}
