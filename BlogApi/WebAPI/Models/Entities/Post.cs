using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string ?Description { get; set; }
        public string? Author { get; set; }
        public string? Banner_Image { get; set; }
        public string? PostedOn { get; set; }
        public ICollection<PostCategory> ?PostCategories { get; set; }
        public ICollection<PostTag> ? postTags { get; set; }

    }
}
