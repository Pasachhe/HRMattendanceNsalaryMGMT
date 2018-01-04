using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanResource.Models
{
    public class AttendanceViewModel
    {

        public string AttendanceId { get; set; }
        public int? EmployeeId { get; set; }
        public string Date { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public double? WorkHours { get; set; }
        public double? Wage { get; set; }

        public string EmployeeName { get; set; }
    }
}