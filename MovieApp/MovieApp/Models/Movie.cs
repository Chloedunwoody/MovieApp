using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Models
{
    public class Movie
    {
        public string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string image;
        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        public string genre;
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
    }
}
