using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Employee> GetAll()
        {
            return base.Employee.ToList();
        }

        public IEnumerable<Employee> GetAll(bool isTimeIn)
        {
            var timeLogEntity = base.Employee
                .Include(r => r.TimeLog);

            var employeeEntity = new List<Employee>();
            foreach (var item in timeLogEntity)
            {
                var hasTimeLog = item.TimeLog.Where(r => r.IsTimeIn == isTimeIn).Count() > 0;
                if (hasTimeLog)
                    employeeEntity.Add(item);
                else
                    if (!isTimeIn && item.TimeLog.Count() == 0) 
                        employeeEntity.Add(item);
            }
            return employeeEntity;
        }


        public Employee GetById(string id)
        {
            return base.Employee.Where(r => r.Id == id).FirstOrDefault();
        }

        public IEnumerable<Employee> Search(string name)
        {
            return base.Employee.Where(r => r.FirstName.Contains(name) || 
            r.MiddleName.Contains(name) || 
            r.LastName.Contains(name))
            .ToList();
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
