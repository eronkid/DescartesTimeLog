using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLog.Business.Interfaces;
using TimeLog.DAL.Data.DescartesModels;
using TimeLog.DAL.DtoModels;
using TimeLog.DAL.Interfaces;

namespace TimeLog.Business.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Create(Employee model)
        {
            try
            {
                _employeeRepository.Create(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Employee> GetAll()
        {
            try
            {
                return _employeeRepository.GetAll().OrderBy(r => r.FirstName).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public List<Employee> GetAll(bool isTimeIn)
        {
            try
            {
                return _employeeRepository.GetAll(isTimeIn).OrderBy(r => r.FirstName).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }            
        }

        public Employee GetById(string id)
        {
            try
            {
                return _employeeRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(EmployeeDto modelDto)
        {
            try
            {
                _employeeRepository.Update(modelDto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Delete(string id)
        {
            try
            {
                _employeeRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
