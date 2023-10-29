using AutoMapper;
using BlogFinalTask.Data.DTOS;
using BlogFinalTask.Data.Models;

namespace BlogFinalTask.Data.Repository
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<Article, ArticleDTO>();
            CreateMap<ArticleDTO, Article>()
                .ForMember(destination => destination.Id, option => option.Ignore());
            CreateMap<Comment, CommentDTO>()
                .AfterMap((src,dest) => dest.UserName = src.User!.UserName!);
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
