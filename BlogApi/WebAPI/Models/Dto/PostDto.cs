namespace WebAPI.Models.Dto
{
    public class PostDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? Banner_Image { get; set; }
        public string? PostedOn { get; set; }
    }
}
