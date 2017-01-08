using LinqExercises.Controllers;
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
    public class ShippersControllerTests
    {
        private ShippersController _shippersController;

        [TestInitialize]
        public void Initialize()
        {
            // ARRANGE
            _shippersController = new ShippersController();
        }

        [TestMethod]
        public void GetFreightReportTest()
        {
            // ACT
            IHttpActionResult actionResult = _shippersController.GetFreightReport();
            var contentResult = actionResult as OkNegotiatedContentResult<IQueryable<object>>;

            // ASSERT
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.Count(), 3);
        }
    }
}
