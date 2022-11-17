namespace WebAPI.Models.Entities
{
    public class PostTag
    {
        public Guid Id { get; set; }
        public int postId { get; set; }
        public int TagID { get; set; }

        public Post? post_ { get; set; }
        public Tag? tag_ { get; set; }
    }
}
