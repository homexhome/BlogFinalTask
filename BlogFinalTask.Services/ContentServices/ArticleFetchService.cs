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
    public class ArticleFetchService{
        private IRepositoryCollection _repo;
        private ClaimsPrincipal _user;

        public ArticleFetchService( IRepositoryCollection repo, ClaimsPrincipal user) {
            _repo = repo;
            _user = user;
        }

        public async Task<List<ArticleDTO>> GetAllArticlesByUser(string id) {
            if (_user is not null && id is not null) {
                var articles = await _repo.Article.GetAllAsync(_user);
                List<ArticleDTO> result = articles.Where(articles => articles.Id == id).ToList();
                return result;
            }
            else {
                return new List<ArticleDTO>();
            }
        }

    }
}
