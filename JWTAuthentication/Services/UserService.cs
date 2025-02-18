using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTAuthentication.Entities;
using JWTAuthentication.Helpers;
using JWTAuthentication.Model;
using JWTAuthentication.Services.Interface;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

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
            var user = users.SingleOrDefault(x=>x.UserName== request.UserName && x.Password==request.Password);

            if(user==null)
            {
                return null;
            }

            var token=generateJwtToken(user);

            return new AuthenticationResponse(user,token);
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User GetUser(int id)
        {
            return users.FirstOrDefault(x=>x.Id==id);
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                            SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
       
    }
}