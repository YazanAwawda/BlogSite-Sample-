namespace WebAPI.Models.Entities
{
    public class PostCategory
    {
        public Guid Id { get; set; }
        public int postId { get; set;  }
        public int categoryId { get; set; }

        public Post ?post_ { get; set; }
        public Category? category_ { get; set; }
    }
}
