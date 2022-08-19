using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLog.DAL.Data.DescartesModels;
using TimeLog.DAL.DtoModels;

namespace TimeLog.DAL.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository
    {
        void Create(Employee model);
        Employee GetById(string id);
        IEnumerable<Employee> Search(string name);
        void Update(EmployeeDto modelDto);
        void Delete(string id);
    }
}
