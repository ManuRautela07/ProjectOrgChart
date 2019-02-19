using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Web.Http.Cors;
using ProjectOrgChart.Models;
using System.Web;
using System.IO;

namespace ProjectOrgChart.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    
    public class DetailsController : ApiController
    {

        //Get controller fetches the details of all employees

        [Route("api/employeedetails")]
        public IEnumerable<EmployeeModel> Get()
        {
    
            using (var entities = new ApplicationDbContext())
            {
                return entities.EmployeeModel.ToList();
            }
        }


        //Get controller with a parameter id returns the details of employee with specific id
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

        //Post method adds a new employee to our table
       public HttpResponseMessage Post([FromBody]EmployeeModel employee)
        {
            try
            {
                using (var entities = new ApplicationDbContext())
                {
                    entities.EmployeeModel.Add(employee);
                    entities.SaveChanges();



                  /*  string imageName = null;
                    var httpRequest = HttpContext.Current.Request;
                    //upload an image
                    var postedFile = httpRequest.Files["Image"];


                    imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
                    imageName = imageName + DateTime.Now.ToString("yymmff") + Path.GetExtension(postedFile.FileName);
                    var filepath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
                    postedFile.SaveAs(filepath);



                System.Diagnostics.Debug.Write("ID is before req-----------------" );

                using (var db = new ApplicationDbContext())
                    {
                    EmployeeModel entity = new EmployeeModel()
                    {

                        Name = employee.Name,
                        Email = employee.Email,
                        Contact=employee.Contact,
                            ImagePath = imageName
                        };

                        db.EmployeeModel.Add(entity);
                        db.SaveChanges();


                */
    


                    }




                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri + "/" + employee.Id.ToString());
                    return message;

                
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        


        //deletes method deletes the employee with specific id
        public HttpResponseMessage delete(int id)
        {


            try
            {
                using (var entities = new ApplicationDbContext())
                {
                    var entity = entities.EmployeeModel.FirstOrDefault(e => e.Id == id);


                    if (entity == null)
                    {

                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id  " + id.ToString() + " not found");
                    }
                    else
                    {
                        entities.EmployeeModel.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);

                    }
                }



            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);


            }


        }

        public HttpResponseMessage Put(int id, [FromBody]EmployeeModel employee)
        {

            try
            {
                using (var entities = new ApplicationDbContext())
                {
                    var entity = entities.EmployeeModel.FirstOrDefault(e => e.Id == id);

                    if (entity == null)
                    {

                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id" + id.ToString() + " not found to update");
                    }

                    else
                    {
                        entity.Name = employee.Name;
                        entity.Email = employee.Email;
                        entity.Contact = employee.Contact;


                        entities.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);


            }
        }




    }
}
