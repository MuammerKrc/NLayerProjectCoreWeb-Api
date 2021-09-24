using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NlayerProject.Service;
using NlayerProject.Service.Mappers;
using NLayerProject.Core.Dtos;
using NLayerProject.Core.Models;
using NLayerProject.Core.Serivces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAllAsync();
            return Ok(ObjMapper.Mapper.Map<List<ProductDto>>(result));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            return Ok(ObjMapper.Mapper.Map<ProductDto>(result));
        }
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithCategoryById(int id)
        {
            var result = await _productService.GetWithCategoryByIdAsync(id);
            return Ok(ObjMapper.Mapper.Map<ProductWithCategoryDto>(result));
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            var result = await _productService.AddASync(ObjMapper.Mapper.Map<Product>(productDto));
            return Created(string.Empty, ObjMapper.Mapper.Map<ProductDto>(result));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _productService.GetByIdAsync(id);
            if (entity==null)
            {
                return BadRequest();
            }
            _productService.Remove(entity);
            return NoContent();
        }
        [HttpPut]
        public IActionResult Update(ProductDto product)
        {
            _productService.Update(ObjMapper.Mapper.Map<Product>(product));
            return NoContent();
        }

    }
}
