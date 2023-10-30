using BlogFinalTask.Data.DTOS;
using BlogFinalTask.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogFinalTask.Services.ContentServices
{
    public class CommentService
    {
        private readonly IRepositoryCollection _repo;
        private ClaimsPrincipal _user;

        public CommentService(IRepositoryCollection repo, ClaimsPrincipal user) {
            _repo = repo;
            _user = user;
        }

        public async Task AddComment(CommentDTO comment, string articleId, string userId) {
            comment.ArticleId = articleId;
            comment.UserId = userId;
            await _repo.Comment.AddObj(_user, comment);
        }

        public async Task<List<CommentDTO>> GetUserComments(string userId) {
            var commentList = await _repo.Comment.GetAllAsync(_user);
            var result = commentList.Where( u=> u.UserId == userId ).ToList();
            return result;
        }
    }
}
