using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.API.Exctentions;
using UdemyNLayerProject.API.Filters;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            if(products == null) { return NotFound(); }
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) { return NotFound(); }
            // 200
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithCategoryById(int id)
        {
            var product = await _productService.GetWithCategoryById(id);
            if (product == null) { return NotFound(); }
            // 200
            return Ok(_mapper.Map<ProductWithCategory>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var v = await _productService.GetAllAsync();
            var name = v.Select(x=>x.Name == productDto.Name).ToString();
            if (name == productDto.Name) { return Conflict(); }//409
            var newProduct = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            // 201
            return Created(string.Empty, _mapper.Map<ProductDto>(newProduct));
        }

        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            var v =  _productService.GetAllAsync().Result;
            //string id = v.Where(x=>x.Id == productDto.Id).FirstOrDefault().ToString();
            if (productDto == null) { return BadRequest(); }
            else if (v.Where(x => x.Id == productDto.Id).FirstOrDefault().ToString() == null) { return BadRequest(); }
            var product = _productService.Update(_mapper.Map<Product>(productDto));
            // 204
            return NoContent();

        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var product = _productService.GetByIdAsync(id).Result;
            if (product == null) { return NotFound(); }
            _productService.Remove(product);
            // 204
            return NoContent();
        }
    }
}
