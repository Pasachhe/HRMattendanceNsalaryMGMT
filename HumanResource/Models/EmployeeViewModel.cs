using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanResource.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public int? UserId { get; set; }
        public int? DepartmentId { get; set; }
        public int? DesId { get; set; }
        public int? Salary { get; set; }
        public bool? IsDeleted { get; set; }
        public int? MinWorkHr { get; set; }
        //public int? Due { get; set; }


        public string DepartmentName { get; set; }
        public string DesName { get; set; }
        public string UserName { get; set; }
        public bool Remember { get; set; }
        public string SiteName { get; set; }

    }
}