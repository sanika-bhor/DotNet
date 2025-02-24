using JWTAuthentication.Entities;
using JWTAuthentication.Model;

namespace JWTAuthentication.Services
{
    public interface IUserService
    {
        public AuthenticationResponse Authenticate(AuthenticationRequest requestData);
        List<User> GetAll();
        User GetById(int id);
    }
}