using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<PostCategory>? PostCategories { get; set; }

    }
}
