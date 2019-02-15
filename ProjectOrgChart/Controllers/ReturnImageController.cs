using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectOrgChart.Controllers
{
    public class ReturnImageController : Controller
    {
        // GET: ReturnImage
        
            public ActionResult Image(string id)
            {
                var dir = Server.MapPath("/Image");
                var path = Path.Combine(dir, id + ".jpg");
                return base.File(path, "Image/jpeg");
            }
        
    }
}