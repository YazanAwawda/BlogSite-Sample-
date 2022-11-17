using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.IRepository;
using WebAPI.Models.Dto;
using WebAPI.Models.Entities;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper map;
        public CategoryController(IMapper mapper , ICategoryRepository categoryRepository) { 
         this.categoryRepository = categoryRepository;  
         this.map = mapper;
        }

        [HttpGet ("CategoryId/{id}")]
        public IActionResult getCategoryById( [FromRoute] int id) {
            var category = map.Map<CategoryDto>(categoryRepository.GetCategory(id));
            if (category == null) { 
            return NotFound();
            }  
            else
            {
                return Ok(category);    
            }
        }

        [HttpGet("AllGategories")]
        public IActionResult getAllCategories() {
            return Ok(this.map.Map<List<CategoryDto>>(categoryRepository.GetCategories()));
        }


        [HttpGet("getPostbyCategory")]
        public IActionResult getPostbyCategory(int categoryId) {
            var post = map.Map<List<PostDto>>(
            categoryRepository.GetPostByCategory(categoryId));
            if (!ModelState.IsValid)
            return BadRequest();
            return Ok(post);
        }

        [HttpDelete("{cID}")]
        public IActionResult deleteCategoryByID(int cID) {
            var category = categoryRepository.CategoryExists(cID);
            var ctor = categoryRepository.DeleteCategory(category);
            return Ok(map.Map<CategoryDto> (ctor));
        }

        [HttpPost("newCategory")]
        public IActionResult postCategory([FromBody] CategoryDto category) {
            var ctor = this.map.Map<Category>(category);
            return Ok(map.Map<CategoryDto>(categoryRepository.CreateCategory(ctor)));
        }

        [HttpPut("{categoryId}")]
        public IActionResult putCategory([FromBody]CategoryDto category) {
            var ctor = this.map.Map<Category>(category);
            categoryRepository.UpdateCategory(ctor);
            return Ok(map.Map<CategoryDto>( ctor));
        }




    }
}
