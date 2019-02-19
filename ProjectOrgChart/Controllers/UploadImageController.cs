using ProjectOrgChart.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Http.Description;
using System.Threading.Tasks;
using System.Text;

namespace ProjectOrgChart.Controllers
{
    public class UploadImageController : ApiController
    {
        private ApplicationDbContext db;
        public UploadImageController()
        {
            db = new ApplicationDbContext();
        }

        [HttpPost]
        public HttpResponseMessage UploadImage()
        {
            string imageName = null;
            var httpRequest = HttpContext.Current.Request;
            //upload an image
            var postedFile = httpRequest.Files["Image"];
            var idd = httpRequest.Form["Identity"];
            int id = Convert.ToInt32(Convert.ToDouble(idd));


            imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yymmff") + Path.GetExtension(postedFile.FileName);
            var filepath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
            postedFile.SaveAs(filepath);





            /* using (var db = new ApplicationDbContext())
             {
                 EmployeeModel image = new EmployeeModel()
                 {


                     ImagePath = imageName
                 };


                 db.SaveChanges();}*/

            char[] charsToTrim = { '.', 'j', 'p', 'g' };
            imageName = imageName.Trim(charsToTrim);

            using (var entities = new ApplicationDbContext())
            {
                var entity = entities.EmployeeModel.FirstOrDefault(e => e.Id == id);

                if (entity == null)
                {

                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id" + id.ToString() + " not found to update");
                }

                else
                {


                    entity.ImagePath = imageName;



                    entities.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
        }

        //public HttpResponseMessage Put(int id)
        //   { try

        //     {
        //         //System.Diagnostics.Debug.Write("ID is-----------------"+id);
        //         string imageName = null;
        //         var httpRequest = HttpContext.Current.Request;
        //         //upload an image
        //         //System.Diagnostics.Debug.Write("ID is before req-----------------" + id);
        //         var postedFile = httpRequest.Files["Image"];



        //         imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
        //         imageName = imageName + DateTime.Now.ToString("yymmff") + Path.GetExtension(postedFile.FileName);
        //         var filepath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
        //         postedFile.SaveAs(filepath);
        //         //using (var entities = new ApplicationDbContext())
        //         //  {
        //         //    var entity = entities.EmployeeModel.FirstOrDefault(e => e.Id == id);

        //         //    if (entity == null)
        //         //    {

        //         //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id" + id.ToString() + " not found to update");
        //         //    }

        //         //    else
        //         //    {


        //         //      entity.ImagePath = imageName;



        //         //        entities.SaveChanges();

        //         //        return Request.CreateResponse(HttpStatusCode.OK, entity);
        //         //    }



        // var entity = db.EmployeeModel.SingleOrDefault(e => e.Id == id);

        //       }
        //       catch (Exception ex)
        //       {
        //           return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);


        //    }

        // }


        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutApplicationUser(int id)
        //{
        //    string imageName = null;
        //    var httpRequest = HttpContext.Current.Request.Files["image"];
        //    System.Diagnostics.Debug.Write("------------------------------"+httpRequest);
        //    //var postedFile = httpRequest.Files[0];
        //    imageName = new String(Path.GetFileNameWithoutExtension(httpRequest.FileName).Take(10).ToArray()).Replace(" ", "-");
        //    imageName = imageName + DateTime.Now.ToString("yymmff") + Path.GetExtension(httpRequest.FileName);
        //    var filepath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
        //    httpRequest.SaveAs(filepath);
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var query = from u in db.EmployeeModel
        //                where u.Id == id
        //                select u;
        //    var user = query.FirstOrDefault();
        //    db.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        //if (!ApplicationUserExists(id))
        //        //{
        //        //    return NotFound();
        //        //}
        //        //else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}



        //[ResponseType(typeof(void))]
        //public async Task<HttpResponseMessage> PutFile(int id)
        //    {
        //        // Check if the request contains multipart/form-data. 
        //        if (!Request.Content.IsMimeMultipartContent())
        //        {
        //            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        //        }

        //        string root = HttpContext.Current.Server.MapPath("~/App_Data");
        //        var provider = new MultipartFormDataStreamProvider(root);

        //        try
        //        {
        //            StringBuilder sb = new StringBuilder(); // Holds the response body 

        //            // Read the form data and return an async task. 
        //            await Request.Content.ReadAsMultipartAsync(provider);

        //            // This illustrates how to get the form data. 
        //            foreach (var key in provider.FormData.AllKeys)
        //            {
        //                foreach (var val in provider.FormData.GetValues(key))
        //                {
        //                    sb.Append(string.Format("{0}: {1}\n", key, val));
        //                }
        //            }

        //            // This illustrates how to get the file names for uploaded files. 
        //            foreach (var file in provider.FileData)
        //            {
        //                FileInfo fileInfo = new FileInfo(file.LocalFileName);
        //                sb.Append(string.Format("Uploaded file: {0} ({1} bytes)\n", fileInfo.Name, fileInfo.Length));
        //            }
        //            return new HttpResponseMessage()
        //            {
        //                Content = new StringContent(sb.ToString())
        //            };
        //        }
        //        catch (System.Exception e)
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
        //        }
        //    }

        



       
    }
}
