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
    public class SuppliersControllerTests
    {
        private SuppliersController _suppliersController;

        [TestInitialize]
        public void Initialize()
        {
            // ARRANGE
            _suppliersController = new SuppliersController();
        }

        [TestMethod]
        public void GetSalesAndMarketingTest()
        {
            // ACT
            IHttpActionResult actionResult = _suppliersController.GetSalesAndMarketing();
            var contentResult = actionResult as OkNegotiatedContentResult<IQueryable<Supplier>>;

            // ASSERT
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.Count(), 5);
        }

        [TestMethod]
        public void SearchSuppliersTest()
        {
            // ACT
            IHttpActionResult actionResult = _suppliersController.SearchSuppliers("rue");
            var contentResult = actionResult as OkNegotiatedContentResult<IQueryable<Supplier>>;

            // ASSERT
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.Count(), 5);
        }
    }
}
