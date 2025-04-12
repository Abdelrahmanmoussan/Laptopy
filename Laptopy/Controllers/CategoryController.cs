using Laptopy.DTOs.Response;
using Laptopy.Repository;
using Laptopy.Repository.IRepository;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laptopy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var categories = _categoryRepository.Get();

            return Ok(categories.Adapt<IEnumerable<CategoryResponse>>());

        }

        [HttpGet("{id}")]
        public IActionResult GetOne([FromRoute] int id)
        {
            var category = _categoryRepository.GetOne(e=>e.Id == id);

            if (category !=  null) 
            return Ok(category.Adapt<CategoryResponse>());

            return NotFound();
        }










    }
}
