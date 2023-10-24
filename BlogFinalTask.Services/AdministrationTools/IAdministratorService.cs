using BlogFinalTask.Data.Models.HelperModels;

namespace BlogFinalTask.Services.AdministrationTools
{
    public interface IAdministratorService
    {
        public Task<List<CustomUserTransferModel>> GetAllUsers();
        public Task<List<string>> GetAllRolesList();
        public Task UpdateUser(CustomUserTransferModel customUserModel);
    }
}
