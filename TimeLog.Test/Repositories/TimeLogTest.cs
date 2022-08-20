using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TimeLog.DAL.Data.DescartesModels;
using TimeLog.DAL.DtoModels;
using TimeLog.DAL.Repositories;

namespace TimeLog.Test
{
    [TestClass]
    public class TimeLogTest
    {
        private string employeeId = "a31daebe-4a74-4150-9ae4-a6af71c1af6e"; // Employee id

        [TestMethod]
        public void TestCreate()
        {
            try
            {
                var model = new DAL.Data.DescartesModels.TimeLog()
                {
                    Id = Guid.NewGuid().ToString(),
                    EmployeeId = employeeId,
                    IsTimeIn = true,
                    TimeIn = DateTime.Now
                };

                var repo = new TimeLogRepository();
                repo.Create(model);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestGetAll()
        {
            var isValid = false;

            try
            {
                var repo = new TimeLogRepository();
                var record = repo.GetAll();
                isValid = record != null;

                Assert.IsTrue(isValid);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(isValid);
            }
        }

        [TestMethod]
        public void TestGetByEmployeeId()
        {
            var isValid = false;

            try
            {
                var repo = new TimeLogRepository();
                var record = repo.GetByEmployeeId(employeeId);
                isValid = record != null;

                Assert.IsTrue(isValid);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(isValid);
            }
        }

        [TestMethod]
        public void TestGetIdByEmployeeId()
        {
            var isValid = false;

            try
            {
                var repo = new TimeLogRepository();
                var id = repo.GetIdByEmployeeId(employeeId);
                isValid = !string.IsNullOrWhiteSpace(id);

                Assert.IsTrue(isValid);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(isValid);
            }
        }

        [TestMethod]
        public void TestUpdateTimeOut()
        {
            try
            {
                var model = new TimeLogDto()
                {
                    EmployeeId = employeeId,
                    IsTimeIn = false
                };

                var repo = new TimeLogRepository();
                var datetime = repo.Update(model);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestUpdateTimeIn()
        {
            try
            {
                var model = new TimeLogDto()
                {
                    EmployeeId = employeeId,
                    IsTimeIn = true
                };

                var repo = new TimeLogRepository();
                var datetime = repo.Update(model);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestDelete()
        {
            try
            {
                var id = ""; // id

                var repo = new TimeLogRepository();
                repo.Delete(id);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false);
            }
        }
    }
}
