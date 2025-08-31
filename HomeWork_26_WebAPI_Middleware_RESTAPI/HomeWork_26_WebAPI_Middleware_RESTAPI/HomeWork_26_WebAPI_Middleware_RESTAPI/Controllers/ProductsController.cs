using HomeWork_26_WebAPI_Middleware_RESTAPI.Data;
using HomeWork_26_WebAPI_Middleware_RESTAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HomeWork_26_WebAPI_Middleware_RESTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetAll()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        // GET: api/product/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> Get(int id)
        {
            var product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();
            return product;
        }

        // POST: api/product
        [HttpPost]
        public async Task<ActionResult<Products>> Create(Products product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Products updatedProduct)
        {
            if (id != updatedProduct.Id)
                return BadRequest();

            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.CategoryId = updatedProduct.CategoryId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Products> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            patchDoc.ApplyTo(product);
            TryValidateModel(product);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }// end class
}//end namespace
