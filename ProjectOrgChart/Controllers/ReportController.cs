using ProjectOrgChart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectOrgChart.Controllers
{
    public class ReportController : ApiController
    {    
       
        public HttpResponseMessage Get(int id)
        {

            try
            {
                using (var entities = new ApplicationDbContext())
                {
                    var entity = entities.EmployeeModel.FirstOrDefault(e => e.Id == id);

                    if (entity == null)
                    {

                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id " + id.ToString() + " not found in the database");
                    }

                    else
                    {
                        var manager = entities.EmployeeModel.FirstOrDefault(e=>e.Id==entity.ReportsTo);

                        if (manager == null)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK,"The employee has no manager"); }
                        else
                        { return Request.CreateResponse(HttpStatusCode.OK, manager); }
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
