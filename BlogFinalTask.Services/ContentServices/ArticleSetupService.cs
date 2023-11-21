using BlogFinalTask.Data.DTOS;
using BlogFinalTask.Data.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogFinalTask.Services.ContentServices;

public class ArticleSetupService
{
    private ArticleDTO _articleDTO { get; set; }
    private List<TagDTO> _tagsDTOs { get; set; }
    private IRepositoryCollection _repo;
    private ClaimsPrincipal _user;
    private string? articleId;

    public ArticleSetupService(IRepositoryCollection repo, ArticleDTO articleDTO,
            List<TagDTO> tagsDTOs, ClaimsPrincipal user) {
        _repo = repo;
        _articleDTO = articleDTO;
        _tagsDTOs = tagsDTOs;
        _user = user;
    }

    public async Task CreateArticle() {
        if (_articleDTO is not null) {
            articleId = await _repo.Article.AddObj(_user, _articleDTO);
            _repo.logger.LogDebug(1, $"{_user.Identity!.Name} created article with title {_articleDTO.Title} at {DateTime.UtcNow}");
        }
    }

    public async Task CreateArticleTags() {
        if (_tagsDTOs.Count > 0) {
            foreach (TagDTO tagDTO in _tagsDTOs) {
                ArticleTagsDTO articleTags = new() {
                    ArticleId = articleId!,
                    TagId = tagDTO.Id
                };
                await _repo.ArticleTags.AddObj(_user, articleTags);
            }
        }
    }
    public async Task UdpateArticleTags(string articleIdToUpdate) {
            articleId = articleIdToUpdate;
            List<ArticleTagsDTO> articleTagsToUpdate = await _repo.ArticleTags.GetDTOByArticleId(articleId!);
            foreach (ArticleTagsDTO articleTagDTO in articleTagsToUpdate) {
                await _repo.ArticleTags.DeleteObj(_user,articleTagDTO.Id);
            }
            await CreateArticleTags();
    }
}

