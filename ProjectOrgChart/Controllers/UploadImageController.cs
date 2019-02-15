using ProjectOrgChart.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ProjectOrgChart.Controllers
{
    public class UploadImageController : ApiController
    {

        [HttpPost]
        [Route("api/uploadimage")]
        public HttpResponseMessage UploadImage()
        {
            string imageName = null;
            var httpRequest = HttpContext.Current.Request;
            //upload an image
            var postedFile = httpRequest.Files["Image"];


            imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yymmff") + Path.GetExtension(postedFile.FileName);
            var filepath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
            postedFile.SaveAs(filepath);


            //custom name
            /*   imageName = new String(Path.GetFileName(postedFile.FileName).ToArray()).Replace(" ", "-");
             imageName = imageName + DateTime.Now.ToString("yymmff")  Path.GetExtension(postedFile.FileName);
               var filepath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
               postedFile.SaveAs(filepath);*/


            /* using (var db = new ApplicationDbContext())
             {
                 EmployeeModel image = new EmployeeModel()
                 {


                     ImagePath = path
                 };

                 db.EmployeeModel.Add(image);
                 db.SaveChanges();






             }*/
            return Request.CreateResponse(HttpStatusCode.Created);





        }



        public HttpResponseMessage Get(int id)
        {

            using (var entities = new ApplicationDbContext())
            {
                var entity = entities.EmployeeModel.FirstOrDefault(e => e.Id == id);

                if (entity != null)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                { return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id " + id + " not found"); }

            }

        }
    }
}
