

using WebAPI.Models.Entities;

namespace WebAPI.IRepository
{
    public interface ITagRepository
    {
        public Task<ICollection<Tag>> GetTags();
        public Tag GetTag(int id);
        public Task<ICollection<Post>> GetPostByTag(int TagId);
        public bool CategoryExists(int id);
        public bool CreateTag(Tag Tag);
        public bool UpdateTag(Tag Tag);
        public bool DeleteTag(Tag Tag);
        public bool Save();
    }
}
