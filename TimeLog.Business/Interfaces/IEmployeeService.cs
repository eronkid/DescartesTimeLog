using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLog.DAL.Data.DescartesModels;
using TimeLog.DAL.DtoModels;

namespace TimeLog.Business.Interfaces
{
    public interface IEmployeeService : IBaseService
    {
        void Create(Employee model);
        List<Employee> GetAll();
        Employee GetById(string id);
        void Update(EmployeeDto modelDto);
        void Delete(string id);
    }
}
