using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectOrgChart.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set;}
        public string Contact { get; set; }
        public string ImagePath { get; set; }
        public int ReportsTo { get; set; }
     

    }
}