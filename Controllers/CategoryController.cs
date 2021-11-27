using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSSQLStoreAPI.Models;

namespace MSSQLStoreAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]  // https://localhost:5001/api/Category
    public class CategoryController: ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context){
            _context = context;
        }

        // Read Categories
        [HttpGet]
        public ActionResult<Category> GetAll()
        {
            var allCategory = _context.Categories.ToList();
            return Ok(allCategory);
        }

        // Get Category by ID
        [HttpGet("{id}")]
        public ActionResult<Category> GetById(int id)
        {
            var Category = _context.Categories.Where(c => c.CategoryId == id);
            return Ok(Category);
        }

        // Create new Category
        [HttpPost]
        public ActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok(category.CategoryId);
        }

        // Update Category
        [HttpPut]
        public ActionResult Update(Category category)
        {
            if(category == null)
            {
                return NotFound();
            }

            _context.Update(category);
            _context.SaveChanges();

            return Ok(category);
        }

        // Delete Category
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var categoryToDelete = _context.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
            if(categoryToDelete == null){
                return NotFound();
            }

            _context.Remove(categoryToDelete);
            _context.SaveChanges();

            return Ok(categoryToDelete);
        }

    }
}