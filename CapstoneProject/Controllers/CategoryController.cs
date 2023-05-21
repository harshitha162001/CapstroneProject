using CapstoneProject.DAL;
using CapstoneProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace CapstoneProject.Controllers
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
        [Route("GetListOfCategoryMedicines")]
        public async Task<List<Category>> GetCategoryAsync()
        {
            try
            {
                return await categoryService.GetCategoryListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("GetCategoryById")]
        public async Task<IEnumerable<Category>> GetCategoryByIdAsync(int Id)
        {
            try
            {
                var response = await categoryService.GetCategoryByIdAsync(Id);
                if (response == null)
                {
                    return null;
                }
                return response;
            }
            catch
            {
                throw;
            }
        }
        [HttpDelete]
        [Route("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await categoryService.DeleteCategoryAsync(Id);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut]
        [Route("AddCategory")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await categoryService.AddCategoryAsync(category);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }
        [HttpPut]
        [Route("EditCategory")]
        public async Task<IActionResult> EditCategory(int Id, Category category)
        {
            if (category == null && Id < 0)
            {
                return BadRequest();
            }
            try
            {
                var response = await categoryService.UpdateCategoryAsync(Id, category);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }
    }
}
