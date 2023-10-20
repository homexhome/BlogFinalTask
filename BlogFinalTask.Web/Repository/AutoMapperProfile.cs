using AutoMapper;
using BlogFinalTask.Web.Data.DTOS;
using BlogFinalTask.Web.Data.Models;

namespace BlogFinalTask.Web.Repository
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<Article, ArticleDTO>();
            CreateMap<ArticleDTO, Article>()
                .ForMember(destination => destination.Id, option => option.Ignore());
            CreateMap<Comment, CommentDTO>();
            CreateMap<CommentDTO, Comment>()
                .ForMember(destination => destination.Id, option => option.Ignore());
            CreateMap<ArticleTags, ArticleTagsDTO>();
            CreateMap<ArticleTagsDTO, ArticleTags>()
                .ForMember(destination => destination.Id, option => option.Ignore());
            CreateMap<Tag, TagDTO>();
            CreateMap<TagDTO, Tag>()
                .ForMember(destination => destination.Id, option => option.Ignore());

        }
    }
}
