using System.Collections.Generic;
using ASPNetCore.WebAPI.Core.Models;

namespace ASPNetCore.WebAPI.Presistance
{
    public class BookPresistance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public KeyValuePresistance Categories { get; set; }
        public List<KeyValuePresistance> Authors { get; set; }

        public BookPresistance()
        {
            Authors = new List<KeyValuePresistance>();
        }
    }
}