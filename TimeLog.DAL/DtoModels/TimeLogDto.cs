using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLog.DAL.DtoModels
{
    public class TimeLogDto
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public bool IsTimeIn { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
    }
}
