using BlogFinalTask.Web.Data;
using BlogFinalTask.Web.Data.DTOS;
using System.Security.Claims;

namespace BlogFinalTask.Web.Repository
{
    public interface IGenericRepository<TEntity, TDTO> 
        where TEntity : class, IEntity
        where TDTO : class, IDTO
    {
        Task<List<TDTO>> GetAllAsync(ClaimsPrincipal User);
        Task<string> AddObj(ClaimsPrincipal User, TDTO dto);
        Task<TDTO> UpdateObj(ClaimsPrincipal user, TDTO dto);
        Task<bool> DeleteObj(ClaimsPrincipal user, string id);
    }
}
