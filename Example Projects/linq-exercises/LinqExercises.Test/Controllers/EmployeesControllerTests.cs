using LinqExercises.Controllers;
using LinqExercises.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace LinqExercises.Test.Controllers
{
    [TestClass]
    public class EmployeesControllerTests
    {
        private EmployeesController _employeesController;

        [TestInitialize]
        public void Initialize()
        {
            // ARRANGE
            _employeesController = new EmployeesController();
        }

        [TestMethod]
        public void GetAllEmployeeTests()
        {
            // ACT
            IHttpActionResult actionResult = _employeesController.GetEmployees();
            var contentResult = actionResult as OkNegotiatedContentResult<IQueryable<Employee>>;

            // ASSERT
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.Count(), 9);
        }

        [TestMethod]
        public void GetAllEmployeesByTitleTests()
        {
            // ACT
            IHttpActionResult actionResult = _employeesController.GetEmployeesByTitle("Sales Representative");
            var contentResult = actionResult as OkNegotiatedContentResult<IQueryable<Employee>>;

            // ASSERT
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.Count(), 6);
        }
    }
}
