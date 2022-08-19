using System.ComponentModel.DataAnnotations;

namespace TimeLog.Web.Models
{
    public class EmployeeViewModel
    {
        public string Id { get; set; }
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }
    }
}
