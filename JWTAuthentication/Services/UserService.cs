using JWTAuthentication.Entities;
using JWTAuthentication.Helpers;
using JWTAuthentication.Model;
using JWTAuthentication.Services.Interface;
using Microsoft.Extensions.Options;

namespace JWTAuthentication.Services
{
    public class UserService : IUserService
    {
       private List<User> users=new List<User>
        {
            new User{Id=1, FirstName="sanika", LastName="bhor",UserName="sanikaB",Password="0236ggvf"},
            new User{Id=2, FirstName="sumit", LastName="bhor",UserName="sumitBhor",Password="ffgud"},
            new User{Id=1, FirstName="Ajinkya", LastName="Tambade",UserName="AJ",Password="truiyre"}
        };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appsetting)
        {
            _appSettings=appsetting.Value;
        }
        public AuthenticationResponse Authenticate(AuthenticationRequest request)
        {
            
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }


        public User GetUser()
        {
            throw new NotImplementedException();
        }
    }
}