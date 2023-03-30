using CategoryService.Dal;
using CategoryService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CategoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DataAccess dataAccess;

        /// <summary>
        /// Dependency Injection
        /// </summary>
        /// <param name="dbAccess"></param>
        public CategoryController(DataAccess dbAccess)
        {
            dataAccess = dbAccess;
        }

        [HttpGet]
        public IActionResult Get()
        { 
            var response = dataAccess.GetAllCategories();
            return Ok(response);
        }
        /// <summary>
        /// HTTP Route URL Template
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = dataAccess.GetCategory(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(Category category)
        {
            var response = dataAccess.CreateCategory(category);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Category category)
        {
            var response = dataAccess.UpdateCategory(id,category);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = dataAccess.DeleteCategory(id);
            return Ok(response);
        }
    }
}
