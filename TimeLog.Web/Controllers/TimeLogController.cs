using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TimeLog.Business.Interfaces;
using TimeLog.DAL.Data.DescartesModels;
using TimeLog.DAL.DtoModels;
using TimeLog.Web.Models;

namespace TimeLog.Web.Controllers
{
    public class TimeLogController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public TimeLogController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: TimeLogController
        public ActionResult Index()
        {
            try
            {
                var employees = _employeeService.GetAll();

                var modelTimeIns = _employeeService.GetAll(true);
                var modelTimeOuts = _employeeService.GetAll(false);

                var viewModel = new TimeLogViewModel()
                {
                    EmployeeTimeIns = GetViewModelEmployeeTime(modelTimeIns),
                    EmployeeTimeOuts = GetViewModelEmployeeTime(modelTimeOuts)
                };
                return View(viewModel);
            }
            catch (System.Exception)
            {
                throw;
            }            
        }

        // GET: TimeLogController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TimeLogController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeLogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeLogController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TimeLogController/Edit/5
        [HttpPost]
        public ActionResult Edit(TimeLogDto modelDto)
        {
            try
            {
                var dt = _employeeService.UpdateTimeLog(modelDto);                
                return Json(new { Success = true, DateTime = dt.ToString("dd MMM yyyy hh:mm:ss tt") });
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeLogController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TimeLogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private List<EmployeeViewModel> GetViewModelEmployeeTime(List<Employee> entities)
        {
            var viewModelTimeOuts = new List<EmployeeViewModel>();
            foreach (var item in entities)
            {
                var timeIn = item.TimeLog.Select(r => r.TimeIn).FirstOrDefault();
                var timeOut = item.TimeLog.Select(r => r.TimeOut).FirstOrDefault();
                var timeInStr = timeIn != null ? timeIn.ToString("dd MMM yyyy hh:mm:ss tt") : "";
                var timeOutStr = timeOut != null ? timeOut?.ToString("dd MMM yyyy hh:mm:ss tt") : "";

                viewModelTimeOuts.Add(new EmployeeViewModel()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    MiddleName = item.MiddleName,
                    LastName = item.LastName,
                    TimeIn = timeInStr,
                    TimeOut = timeOutStr
                });
            }

            return viewModelTimeOuts;
        }
    }
}
