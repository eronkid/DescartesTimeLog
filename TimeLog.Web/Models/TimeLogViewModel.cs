using System.Collections.Generic;

namespace TimeLog.Web.Models
{
    public class TimeLogViewModel
    {
        public List<EmployeeViewModel> EmployeeTimeIns { get; set; }
        public List<EmployeeViewModel> EmployeeTimeOuts { get; set; }
    }
}
