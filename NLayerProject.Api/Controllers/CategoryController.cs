using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(ObjMapper.Mapper.Map<List<CategoryDto>>(categories));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _categoryService.GetByIdAsync(id);
            return Ok(ObjMapper.Mapper.Map<CategoryDto>(entity));
        }
        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWityProductsById(int id)
        {
            var entity = await _categoryService.GetWithProductsByIdAsync(id);
            
            return Ok(ObjMapper.Mapper.Map<CategoryWithProductsDto>(entity));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto category)
        {
            var result = await _categoryService.AddASync(ObjMapper.Mapper.Map<Category>(category));

            return Created(string.Empty, ObjMapper.Mapper.Map<CategoryDto>(result));
        }
        [HttpPut]
        public IActionResult Update(CategoryDto category)
        {
            var result = _categoryService.Update(ObjMapper.Mapper.Map<Category>(category));

            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _categoryService.GetByIdAsync(id);
            if(entity==null)
            {
                return BadRequest();
            }
            _categoryService.Remove(entity);
            return NoContent();
        }
        

    }
}
