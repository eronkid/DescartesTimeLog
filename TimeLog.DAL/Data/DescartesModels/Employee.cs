using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TimeLog.DAL.Data.DescartesModels
{
    public partial class Employee
    {
        public Employee()
        {
            TimeLog = new HashSet<TimeLog>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<TimeLog> TimeLog { get; set; }
    }
}
