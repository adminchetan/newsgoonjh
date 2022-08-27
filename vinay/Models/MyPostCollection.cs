using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vinay.Models
{
    public class MyPostCollection
    {
        public string PostDescription { get; set; }
        public HttpPostedFileBase PostImage { get; set; }
        public string PostImagePath { get; set; }
        public HttpPostedFileBase PostImage1 { get; set; }
        public HttpPostedFileBase PostImage2 { get; set; }
        public HttpPostedFileBase PostVideo { get; set; }
        public string PostLat { get; set; }
        public string PostLng { get; set; }

    }
}