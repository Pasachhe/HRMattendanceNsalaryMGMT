using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace HumanResource.Models
{
    public class RegistrationViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }

        public string Address { get; set; }

        public int? RoleId { get; set; }
    }
}