using Microsoft.AspNetCore.Authorization;

namespace BlogFinalTask.Services.AdministrationTools
{
    public class CustomAuthorizationService : IAuthorizeData
    {
        public string? Policy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? Roles { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? AuthenticationSchemes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
