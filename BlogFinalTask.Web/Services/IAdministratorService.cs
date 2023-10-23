using BlogFinalTask.Web.Data.Models.HelperModels;

namespace BlogFinalTask.Web.Services
{
    public interface IAdministratorService
    {
        public Task<List<CustomUserTransferModel>> GetAllUsers();
        public Task<List<string>> GetAllRolesList();
        public Task UpdateUser(CustomUserTransferModel customUserModel);
    }
}
