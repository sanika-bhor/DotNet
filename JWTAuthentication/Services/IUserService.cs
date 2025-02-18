using JWTAuthentication.Entities;
using JWTAuthentication.Model;

namespace JWTAuthentication.Services.Interface
{
    public interface IUserService
    {
        AuthenticationResponse Authenticate(AuthenticationRequest request);
        List<User> GetAllUsers();
        User GetUser();
    }
}