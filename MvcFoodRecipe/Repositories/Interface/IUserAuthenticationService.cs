using MvcFoodRecipe.Models.DTO;

namespace MvcFoodRecipe.Repositories.Interface
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task LogoutAsync();
        Task<Status> RegisterAsync(RegistrationModel model);
    }
}
