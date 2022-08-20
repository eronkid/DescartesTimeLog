using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TimeLog.Business.Interfaces;
using TimeLog.DAL.Data.DescartesModels;
using TimeLog.DAL.DtoModels;
using TimeLog.Web.Models;

namespace TimeLog.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: Employee
        public ActionResult Index()
        {
            try
            {
                var model = _employeeService.GetAll();
                var viewModel = new List<EmployeeViewModel>();
                foreach (var item in model)
                {
                    viewModel.Add(new EmployeeViewModel()
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        MiddleName = item.MiddleName,
                        LastName = item.LastName
                    });
                }

                return View(viewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            var model = new EmployeeViewModel();
            return View(model);
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new Employee()
                    {
                        Id = Guid.NewGuid().ToString(),
                        FirstName = collection["FirstName"],
                        MiddleName = collection["MiddleName"],
                        LastName = collection["LastName"]
                    };
                    _employeeService.Create(model);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(string id)
        {
            var entity = _employeeService.GetById(id);
            var viewModel = new EmployeeViewModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                MiddleName = entity.MiddleName,
                LastName = entity.LastName
            };
            return View(viewModel);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                var modelDto = new EmployeeDto()
                {
                    Id = id,
                    FirstName = collection["FirstName"],
                    MiddleName = collection["MiddleName"],
                    LastName = collection["LastName"]
                };
                _employeeService.Update(modelDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Search(string name)
        {
            try
            {
                var employees = (name != null) ? _employeeService.Search(name) : _employeeService.GetAll();
                var searchedEmployees = new List<EmployeeViewModel>();
                foreach (var item in employees)
                {
                    searchedEmployees.Add(new EmployeeViewModel()
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        MiddleName = item.MiddleName,
                        LastName = item.LastName
                    });
                }
                return Json(new { Success = true, Employees = searchedEmployees });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false });
            }
            
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public bool Delete(string id)
        {
            try
            {
                _employeeService.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
