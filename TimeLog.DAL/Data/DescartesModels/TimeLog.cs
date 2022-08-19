using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TimeLog.DAL.Data.DescartesModels
{
    public partial class TimeLog
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public bool IsTimeIn { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
