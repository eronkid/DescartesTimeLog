using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TimeLog.DAL.Data.DescartesModels;
using TimeLog.DAL.DtoModels;
using TimeLog.DAL.Repositories;

namespace TimeLog.Test
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void TestCreate()
        {
            try
            {
                var model = new Employee()
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Keanu",
                    LastName = "Reeves"
                };

                var repo = new EmployeeRepository();
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
                var repo = new EmployeeRepository();
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
        public void TestGetAllTimeInAndOut()
        {
            var isValid = false;

            try
            {                
                var isTimeIn = true;

                var repo = new EmployeeRepository();
                var record = repo.GetAll(isTimeIn);
                isValid = record != null;

                Assert.IsTrue(isValid);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(isValid);
            }
        }

        [TestMethod]
        public void TestGetById()
        {
            var isValid = false;

            try
            {
                var id = ""; // Employee id

                var repo = new EmployeeRepository();
                var record = repo.GetById(id);
                isValid = record != null;

                Assert.IsTrue(isValid);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(isValid);
            }
        }

        [TestMethod]
        public void TestSearch()
        {
            var isValid = false;

            try
            {
                var name = ""; // Search name

                var repo = new EmployeeRepository();
                var record = repo.Search(name);
                isValid = record != null;

                Assert.IsTrue(isValid);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(isValid);
            }
        }

        [TestMethod]
        public void TestUpdate()
        {
            try
            {
                var id = ""; // Employee id

                var model = new EmployeeDto()
                {
                    Id = id,
                    FirstName = "Keanu",
                    LastName = "Reeves"
                };

                var repo = new EmployeeRepository();
                repo.Update(model);
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
                var id = ""; // Employee id

                var repo = new EmployeeRepository();
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
