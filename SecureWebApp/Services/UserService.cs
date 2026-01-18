using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SecureWebApp.Entities;
using SecureWebApp.Helpers;
using SecureWebApp.Models;

namespace SecureWebApp.Services
{
    public class UserService : IUserService
    {

        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Ganesh", LastName = "Shinde", Username = "ganesh", Password = "test" },
            new User { Id = 2, FirstName = "Ankur", LastName = "Prasad", Username = "ankur", Password = "test" },
            new User { Id = 3, FirstName = "Neha", LastName = "Bhor",    Username = "neha", Password = "test" },
            new User { Id = 4, FirstName = "Vishwambhar", LastName = "Kapre",Username = "vishwambhar", Password = "test" }
        };
         
         private readonly AppSettings _appSettings ;

         public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings=appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
           var user=_users.SingleOrDefault(x => x.UserName == model.UserName  && x.Password==model.Password);

           if(user==null)
            {
                return null;
            }

            var token=generateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
           return _users.FirstOrDefault(x => x.Id==id);
        }



        private string generateJwtToken(User user)
        {
            var tokenHandler=new JwtSecurityTokenHandler();
            var key=Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor=new SecurityTokenDescriptor
            {
                Subject=new ClaimsIdentity(new[]{new Claim("id",user.Id.ToString())}),
                Expires=DateTime.UtcNow.AddDays(1),
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),
                                            SecurityAlgorithms.HmacSha256Signature)
            };

            var token= tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}