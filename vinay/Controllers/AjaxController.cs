using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vinay.Models;

namespace vinay.Controllers
{
    public class AjaxController : Controller
    {

        string strcon = ConfigurationManager.ConnectionStrings["Vinayconstring"].ConnectionString;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult createcreatePostByAjaxPost()
        {
            return View();
        }


        public JsonResult GetLastFivePosts()
        {
            List<vm_MyPostCollection> allpost = new List<vm_MyPostCollection>();

           
            SqlConnection vinaycon = new SqlConnection(strcon);
            vinaycon.Open();
            SqlCommand sqlCommand = new SqlCommand("Sp_GetLast5PostRightSide", vinaycon);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sqlCommand.ExecuteReader();

            while (sdr.Read())
            {
                allpost.Add(new vm_MyPostCollection
                {

                    PostId = Convert.ToInt32(sdr["PostId"]),
                    PostDescription = sdr["Description"].ToString(),
                    Title = sdr["Title"].ToString(),
                    PostImage = sdr["Image"].ToString(),
                    Postedby = sdr["Postedby"].ToString(),
                    Date = sdr["Date"].ToString(),
                    Time = sdr["time"].ToString()


                });
            }
            vinaycon.Close();
            return Json(new {data=allpost },JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult createPostByAjax(string PostDescription, string Title, HttpPostedFileBase PostImage)
              {

        
            SqlConnection vinaycon = new SqlConnection(strcon);
            vinaycon.Open();
            var allowedExtensions = new[]
              {
                   ".Jpg", ".png", ".jpg", "jpeg",".webp", ".webp"
               };
             var ext = Path.GetExtension(PostImage.FileName);

            SqlCommand sqlCommand = new SqlCommand("Sp_InsertPostMaster", vinaycon);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Title", Title);
            sqlCommand.Parameters.AddWithValue("@Description", PostDescription);
            string date = DateTime.Now.ToString("yyyyMMddHHmmss");


            if (PostImage != null)
            {
                string ImageFileName = date + Path.GetFileName(PostImage.FileName);
                string physicalPath = Path.Combine(Server.MapPath("~/UploadedImages"), date + Path.GetFileName(PostImage.FileName));
                PostImage.SaveAs(physicalPath);
                string ImagePath = "../UploadedImages/" + ImageFileName; //server save!!
                sqlCommand.Parameters.AddWithValue("@Image", ImagePath);
            }
            sqlCommand.Parameters.AddWithValue("@Postedby", "champak");
            SqlParameter outputParam = sqlCommand.Parameters.Add("@result", SqlDbType.Int);
            outputParam.Direction = ParameterDirection.Output;
            sqlCommand.ExecuteNonQuery();
            String res = outputParam.Value.ToString();


            if (res == "1")
            {
                return Json(new
                {
                    data = "data inserted suceesfully"
                }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { data = "Yerr" },JsonRequestBehavior.AllowGet);

            }
        }

    }
}
