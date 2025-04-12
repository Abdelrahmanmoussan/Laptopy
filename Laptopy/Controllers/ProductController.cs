using Laptopy.DTOs.Response;
using Laptopy.Models;
using Laptopy.Repository;
using Laptopy.Repository.IRepository;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laptopy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductImagesRepository _productImagesRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IProductImagesRepository productImagesRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _productImagesRepository = productImagesRepository;
        }

        [HttpGet ("")]
        public IActionResult GetAll()
        {
            var products = _productRepository.Get();

            return Ok(products.Adapt<IEnumerable<ProductResponse>>());
        }

        [HttpGet("{id}")]
        public IActionResult GetOne([FromRoute] int id)
        {
            var product = _productRepository.GetOne(e=>e.Id == id);

            if (product !=  null)
            return Ok(product.Adapt<ProductResponse>());

            return NotFound();
        }








    }
}
