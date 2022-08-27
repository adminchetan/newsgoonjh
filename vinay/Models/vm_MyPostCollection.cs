using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vinay.Models
{
    public class vm_MyPostCollection
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string PostDescription { get; set; }
        public string PostImage { get; set; }
        public string Postedby { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public string PostImagePath { get; set; }
        public HttpPostedFileBase PostImage1 { get; set; }
        public HttpPostedFileBase PostImage2 { get; set; }
        public HttpPostedFileBase PostVideo { get; set; }
        public string PostLat { get; set; }
        public string PostLng { get; set; }
    }
}