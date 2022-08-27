using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vinay.Models;

namespace vinay.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult createPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult createPost(MyPostCollection collections)
        {

            string filename = Path.GetFileNameWithoutExtension(collections.PostImage.FileName);
            string extention = Path.GetExtension(collections.PostImage.FileName);
            filename = filename + DateTime.Now.ToString("yymmssff") + extention;
            collections.PostImagePath = "/Content/ImagesByUser/" + filename;
            filename = Path.Combine(Server.MapPath("/Content/ImagesByUser/"), filename);
            collections.PostImage.SaveAs(filename);
            try
            {
                SqlParameter postname = new SqlParameter();
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.ToString();
            }
                return View();
        }
    }
}