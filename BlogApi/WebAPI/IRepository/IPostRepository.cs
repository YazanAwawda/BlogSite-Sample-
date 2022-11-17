
using WebAPI.Models.Dto;
using WebAPI.Models.Entities;

namespace WebAPI.IRepository
{
    public interface IPostRepository
    {
        public  Task<IAsyncEnumerable<Post>> GetAllPosts();

        public  Task<Post> GetPost(int id);

        public  Task<IList<Post>> GetUserPost(String Author);

        /*public Task<IActionResult> AddUser(string userName,
        string email, string password);*/

        public void AddPost(Post post);
        public bool CreatePost(int tagID , int CategoryId , Post post);
        public bool UpdatePost(int tagID, int CategoryId, Post post);

        public bool Save();
        public Task<Post> EditComment(UpdatePost updatepost);

        public void DeletePost(int id);


    }
}
