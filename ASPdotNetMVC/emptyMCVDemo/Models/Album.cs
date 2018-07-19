using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emptyMCVDemo.Models
{
    public class Album
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Format { get; set; }
        public decimal Price { get; set; }

        public Album (string title, string artist, string format, decimal price)
        {
            Title = title;
            Artist = artist;
            Format = format;
            Price = price;
        }

    }
}