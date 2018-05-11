using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class BloggerPost
    {
        public string id { get; set; }
        public string published { get; set; }
        public string updated { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public BloggerPostAuthor author { get; set; }
        public BloggerPostReply replies { get; set; }
    }
}