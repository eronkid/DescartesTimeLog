using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLog.DAL.Data.DescartesModels;
using TimeLog.DAL.DtoModels;
using TimeLog.DAL.Interfaces;

namespace TimeLog.DAL.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public void Create(Employee model)
        {
            model.DateCreated = DateTime.Now;
            base.Employee.Add(model);
            base.SaveChanges();
        }

        public Employee GetById(string id)
        {
            return base.Employee.Where(r => r.Id == id).FirstOrDefault();
        }

        public void Update(EmployeeDto modelDto)
        {
            var model = GetById(modelDto.Id);
            model.FirstName = modelDto.FirstName;
            model.MiddleName = modelDto.MiddleName;
            model.LastName = modelDto.LastName;
            model.DateModified = DateTime.Now;
            
            base.Employee.Attach(model);
            base.SaveChanges();
        }

        public void Delete(string id)
        {
            var model = new Employee() { Id = id };
            base.Employee.Attach(model);
            base.Employee.Remove(model);
            base.SaveChanges();
        }
    }
}
