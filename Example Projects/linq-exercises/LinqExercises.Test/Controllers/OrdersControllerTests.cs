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
    public class OrdersControllerTests
    {
        private OrdersController _ordersController;

        [TestInitialize]
        public void Initialize()
        {
            // ARRANGE
            _ordersController = new OrdersController();
        }

        [TestMethod]
        public void GetOrdersBetweenDateTest()
        {
            // ACT
            IHttpActionResult actionResult = _ordersController.GetOrdersBetween(DateTime.Parse("01/01/1997"), DateTime.Parse("12/31/1997"));
            var contentResult = actionResult as OkNegotiatedContentResult<IQueryable<Order>>;

            // ASSERT
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.Count(), 398);
        }

        [TestMethod]
        public void PurchaseReportTest()
        {
            // ACT
            IHttpActionResult actionResult = _ordersController.PurchaseReport();
            var contentResult = actionResult as OkNegotiatedContentResult<IQueryable<object>>;

            // ASSERT
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.Count(), 77);
        }
    }
}
