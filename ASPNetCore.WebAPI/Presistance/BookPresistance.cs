using System.Collections.Generic;
using ASPNetCore.WebAPI.Core.Models;

namespace ASPNetCore.WebAPI.Presistance
{
    public class BookPresistance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Categories { get; set; }
        public List<Author> Authors { get; set; }
    }
}