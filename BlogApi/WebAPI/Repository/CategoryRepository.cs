using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using WebAPI.Data;
using WebAPI.IRepository;
using WebAPI.Models.Entities;

namespace WebAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly DataContext context;

        public CategoryRepository(DataContext _context)
        {
            this.context = _context;
        }
        public Category CategoryExists(int id)
        {
          return context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public bool CreateCategory(Category category)
        {
            context.Add(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            context.Remove(category);
            return Save();  
        }

        public ICollection<Category> GetCategories()
        {
            return context.Categories.ToList();
        }

        public  Category GetCategory(int id)
        {
          return   context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public  ICollection<Post> GetPostByCategory(int categoryId)
        {
        return  context.postCategories.Where(e => e.categoryId == categoryId).Select(c => c.post_).ToList();
        }

        public bool Save()
        {
            //Ternary Operation
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
          context.Update(category);
            return Save();
        }
    }
}
