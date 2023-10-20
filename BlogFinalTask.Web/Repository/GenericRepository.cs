using BlogFinalTask.Web.Data.DTOS;
using BlogFinalTask.Web.Data;
using AutoMapper;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace BlogFinalTask.Web.Repository
{
    public class GenericRepository<TEntity, TDTO> : IGenericRepository<TEntity, TDTO>
        where TEntity : class, IEntity
        where TDTO : class, IDTO
    {
        protected readonly ApplicationDbContext context;
        protected readonly IMapper mapper;

        public GenericRepository(ApplicationDbContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }


        protected string? GetMyUserId(ClaimsPrincipal User) {
            Claim? uid = User?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            if (uid is not null) {
                return uid.Value;
            }
            else {
                return null;
            }
        }

        public virtual async Task<List<TDTO>> GetAllAsync(ClaimsPrincipal User) {
            string? userId = GetMyUserId(User);
            if (userId is not null) {
                List<TEntity> entities = await context.Set<TEntity>().ToListAsync();
                List<TDTO> result = mapper.Map<List<TDTO>>(entities);
                return result;
            }
            else {
                return new List<TDTO>();
            }
        }
    }
}
