using AutoMapper;
using BlogFinalTask.Data.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlogFinalTask.Data.Repository
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

        [NonAction]
        public string? GetMyUserId(ClaimsPrincipal User) {
            Claim? uid = User?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            if (uid is not null) {
                return uid.Value;
            }
            else {
                return null;
            }
        }

        [NonAction]
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
        [NonAction]
        public virtual async Task<string> AddObj(ClaimsPrincipal User, TDTO dto) {
            string? userId = GetMyUserId(User);
            if (userId is not null) {
                dto.Id = System.Guid.NewGuid().ToString();
                TEntity toAdd = mapper.Map<TEntity>(dto);
                await context.Set<TEntity>().AddAsync(toAdd);
                return toAdd.Id;
            }
            else {
                return null!;
            }
        }

        [NonAction]
        public virtual async Task<TDTO> UpdateObj(ClaimsPrincipal User, TDTO dto) {
            string? userId = GetMyUserId(User);
            if (userId is not null) {
                TEntity? toUpdate =
                    await context.Set<TEntity>().Where(e => e.Id == dto.Id).FirstOrDefaultAsync();
                if (toUpdate is not null) {
                    mapper.Map<TDTO, TEntity>(dto, toUpdate);
                    context.Entry(toUpdate).State = EntityState.Modified;
                    TDTO result = mapper.Map<TDTO>(toUpdate);
                    return result;
                }
                else {
                    return null!;
                }
            }
            else {
                return null!;
            }
        }

        [NonAction]
        public virtual async Task<bool> DeleteObj(ClaimsPrincipal User, string id) {
            string? userId = GetMyUserId(User);
            if (userId is not null) {
                TEntity? entity =
                    await context.Set<TEntity>().Where(e => e.Id == id).FirstOrDefaultAsync();
                if (entity is not null) {
                    context.Remove(entity);
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }

    }
}
