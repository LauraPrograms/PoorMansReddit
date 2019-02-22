using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoorMansRedit.Models
{
    public class Post
    {
        public string Title { get; set; }
        public string Permalink { get; set; }
        public string Image { get; set; }

        public Post (string title, string permalink, string image)
        {
            Title = title;
            Permalink = permalink;
            Image = image;

        }
        //public Post() { }
    }
}