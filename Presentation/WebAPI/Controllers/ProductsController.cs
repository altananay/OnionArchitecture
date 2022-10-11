using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Net;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductService _productService;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IProductService productService)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _productService = productService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var result = _productReadRepository.GetById(id);
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productReadRepository.GetAll();
            return Ok(result);
        }

        [HttpPost("addproduct")]
        public IActionResult AddProduct(Product product)
        {
            var result = _productService.Add(product);
            return Ok(result);
        }

        [HttpPost("deletebyid")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var result = await _productWriteRepository.Delete(id);
            return Ok(result);
        }
    }
}