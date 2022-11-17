
using WebAPI.Models.Dto;
using WebAPI.Models.Entities;

namespace WebAPI.IRepository
{
    public interface ICommentRepository
    {


        public  Task<IQueryable<Post>> GetPost(int id);


        public  Task<Comment> GetUserComment(string userName);

        public  void AddComment(Comment comment);

        public  Task<Comment> EditComment(UpdateComment updatecomment);

        public  void DeleteComment(int id);

        public  void DeleteAllComment(int id);

}
}
