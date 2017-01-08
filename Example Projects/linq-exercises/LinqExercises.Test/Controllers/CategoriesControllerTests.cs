using LinqExercises.Controllers;
using LinqExercises.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace LinqExercises.Test.Controllers
{
    [TestClass]
    public class CategoriesControllerTests
    {
        private CategoriesController _categoriesController;

        [TestInitialize]
        public void Initialize()
        {
            // ARRANGE
            _categoriesController = new CategoriesController();
        }

        [TestMethod]
        public void GetAllTest()
        {
            // ARRANGE
            _categoriesController = new CategoriesController();

            // ACT
            IHttpActionResult actionResult = _categoriesController.GetAll();
            var contentResult = actionResult as OkNegotiatedContentResult<DbSet<Category>>;

            // ASSERT
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.Count(), 8);
        }

        [TestMethod]
        public void SearchTest()
        {
            // ACT
            IHttpActionResult actionResult = _categoriesController.Search("Co");
            var contentResult = actionResult as OkNegotiatedContentResult<IQueryable<Category>>;

            // ASSERT
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.Count(), 2);
        }
    }
}
