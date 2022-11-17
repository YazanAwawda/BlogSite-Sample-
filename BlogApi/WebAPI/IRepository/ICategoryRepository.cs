

using WebAPI.Models.Entities;

namespace WebAPI.IRepository
{
    public interface ICategoryRepository
    {
       public ICollection<Category> GetCategories();
       public Category GetCategory(int id);

       public ICollection<Post> GetPostByCategory(int categoryId);
       
       public  Category CategoryExists(int id);
       public bool CreateCategory(Category category);
       public bool UpdateCategory(Category category);
       public bool DeleteCategory(Category category);
       public  bool Save();
    }
}
