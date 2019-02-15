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

namespace ProjectOrgChart.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DetailsController : ApiController
    {
        public IEnumerable<EmployeeModel> Get()
        {
    
            using (var entities = new ApplicationDbContext())
            {
                return entities.EmployeeModel.ToList();
            }
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

        public HttpResponseMessage Post([FromBody]EmployeeModel employee)
        {
            try
            {
                using (var entities = new ApplicationDbContext())
                {
                    entities.EmployeeModel.Add(employee);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri + "/" + employee.Id.ToString());
                    return message;

                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }



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

        public HttpResponseMessage put(int id, [FromBody]EmployeeModel employee)
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
