using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class BloggerPostAuthor
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string url { get; set; }
        public BloggerPostImage image { get; set; }
    }
}