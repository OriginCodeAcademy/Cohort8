using LinqExercises.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace LinqExercises.Controllers
{
    public class CategoriesController : ApiController
    {
        private NORTHWNDEntities _db;

        public CategoriesController()
        {
            _db = new NORTHWNDEntities();
        }

        //GET: /api/categories
        [HttpGet, Route("api/categories"), ResponseType(typeof(IQueryable<Category>))]
        public IHttpActionResult GetAll()
        {
            return Ok(_db.Categories);
        }

        //GET: /api/categories/search?term={term}
        [HttpGet, Route("api/categories/search"), ResponseType(typeof(IQueryable<Category>))]
        public IHttpActionResult Search(string term)
        {
            // Write a query to return all categories where the category name 
            // contains the search term.
            var resultSet = from category in _db.Categories
                            where category.CategoryName.Contains(term)
                            select category;

            return Ok(resultSet);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }
    }
}
