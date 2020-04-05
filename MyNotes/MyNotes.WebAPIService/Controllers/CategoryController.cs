using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNotes.Business.Abstract;
using MyNotes.Entities;
using MyNotes.WebAPIService.Filters;
using MyNotes.WebAPIService.Models;

namespace MyNotes.WebAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        [CategoryException]
        public IActionResult Get()
        {
            ServiceResponse<Category> response = new ServiceResponse<Category>
            {
                Entities = categoryService.GetAll(),
                IsSuccesful = true
            };
            response.EntitiesCount = response.Entities.Count();
            return Ok(response);
        }
        [HttpGet("{id}")]
        [CategoryException]
        public IActionResult Get(int id)
        {
            ServiceResponse<Category> response = new ServiceResponse<Category>
            {
                Entity = categoryService.GetById(id),
                IsSuccesful = true
            };
            return Ok(response);
        }
        [HttpPost]
        [CategoryException]
        [CategoryValidate]
        public IActionResult Post([FromBody] CategoryModel model)
        {
            Category category = new Category
            {
                CategoryName = model.CategoryName
            };
            categoryService.Add(category);

            ServiceResponse<Category> response = new ServiceResponse<Category>
            {
                Entity = category,
                IsSuccesful = true
            };

            return Ok();
        }

        [HttpPut]
        [CategoryException]
        [CategoryValidate]
        public IActionResult Put(int id, [FromBody] CategoryModel model)
        {
            ServiceResponse<Category> response = new ServiceResponse<Category>();
            var category = categoryService.GetById(id);
            if (category==null)
            {
                response.HasErrors = true;
                response.Errors.Add("Kategory bulunamadı!");
                return BadRequest(response);
            }
            category.CategoryName = model.CategoryName;
            categoryService.Update(category);
            response.IsSuccesful = true;
            return Ok(response);
        }

        [HttpDelete]
        [CategoryException]
        public IActionResult Delete(int id)
        {
            ServiceResponse<Category> response = new ServiceResponse<Category>();
            var category = categoryService.GetById(id);
            if (category == null)
            {
                response.HasErrors = true;
                response.Errors.Add("Kategory bulunamadı!");
                return BadRequest(response);
            }
            categoryService.Delete(category);
            response.IsSuccesful = true;
            return Ok(response);
        }

    }
}