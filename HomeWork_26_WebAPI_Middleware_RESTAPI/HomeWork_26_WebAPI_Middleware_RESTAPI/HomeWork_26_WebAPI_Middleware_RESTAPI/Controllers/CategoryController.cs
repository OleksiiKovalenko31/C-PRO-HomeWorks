using HomeWork_26_WebAPI_Middleware_RESTAPI.Data;
using HomeWork_26_WebAPI_Middleware_RESTAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

namespace HomeWork_26_WebAPI_Middleware_RESTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAllCategories), new { id = category.Id }, category);
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException != null ? ex.InnerException.Message : "Внутрішня помилка відсутня";
                return StatusCode(500, $"Помилка сервера: {ex.Message}. Inner Exception: {innerMessage}");
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
                return NotFound(); // 404, якщо не знайшли

            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category updatedCategory)
        {
            if (id != updatedCategory.Id)
                return BadRequest("ID в URL і в тілі запиту мають співпадати");

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            category.Name = updatedCategory.Name;

            await _context.SaveChangesAsync();

            return NoContent(); // 204 - успішне оновлення без повернення даних
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchCategory(int id, [FromBody] JsonPatchDocument<Category> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            patchDoc.ApplyTo(category);

            TryValidateModel(category);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent(); // 204 – успішне видалення без контенту
        }
    }// End of class

}// End of code