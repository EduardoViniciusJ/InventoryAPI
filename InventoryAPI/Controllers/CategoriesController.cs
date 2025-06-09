using Inventory.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using TestesAPI.Models;
namespace TestesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _uof;

        public CategoriesController(ICategoryRepository categoryRepository, IUnitOfWork uof)
        {
            _categoryRepository = categoryRepository;
            _uof = uof;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepository.GetAllAsync();
            if(categories == null)
            {
                return NotFound("No categories found.");
            }
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if(category == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            return Ok(category);
        }

        [HttpGet("name/{name}")]   
        public async Task<IActionResult> GetByName(string name)
        {
            var category = await _categoryRepository.GetByNameAsync(name);
            if(category == null)
            {
                return NotFound($"Category with name '{name}' not found.");
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            if(category == null)
            {
                return BadRequest("Category cannot be null.");
            }
            var existingCategory = await _categoryRepository.GetByNameAsync(category.Name);
            if(existingCategory != null)
            {
                return Conflict($"Category with name '{category.Name}' already exists.");
            }
            var createdCategory = await _categoryRepository.CreateAsync(category);
            await _uof.CommitAsync();
            return CreatedAtAction(nameof(GetById), new { id = createdCategory.Id }, createdCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Category category)
        {
            if(category == null || category.Id != id)
            {
                return BadRequest("Category data is invalid.");
            }
            var existingCategory = await _categoryRepository.GetByIdAsync(id);
            if(existingCategory == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            existingCategory.Name = category.Name;
            existingCategory.Active = category.Active;
            existingCategory.RegistrationDate = DateTime.Now; 
            
            _categoryRepository.Update(existingCategory);
            await _uof.CommitAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(id);
            if(existingCategory == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            var deleted = await _categoryRepository.DeleteAsync(id);
            if(!deleted)
            {
                return BadRequest("Failed to delete the category.");
            }
            await _uof.CommitAsync();
            return NoContent();
        }
    }
}
