using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Models
{
    internal class BookmarkedProperty
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public bool IsBookmarked { get; set; }


    }
}
