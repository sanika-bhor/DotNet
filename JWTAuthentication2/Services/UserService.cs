using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTAuthentication.Entities;
using JWTAuthentication.Helper;
using JWTAuthentication.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuthentication.Services
{
    public class UserService : IUserService
    {
        public AppSettings _appSetting;
        List<User> users=new List<User>
        {
            new User{Id=1,FirstName="sanika", LastName="Bhor",UserName="sanika05"},
            new User{Id=2,FirstName="sumit", LastName="Bhor",UserName="sumit06"},
            new User{Id=3,FirstName="Ajinkya", LastName="Tambade",UserName="AJ45"}
        };

        public UserService(IOptions<AppSettings> appSetting)
        {
            _appSetting = appSetting.Value;
        }
        public AuthenticationResponse Authenticate(AuthenticationRequest requestData)
        {
            var user=users.SingleOrDefault(x=>x.UserName==requestData.UserName && x.Password==requestData.Password);
            if (user == null)
            {
                return null;
            }
            
            string token=generateJWTWebToken(user);
            return new AuthenticationResponse(user,token);
        }

        private string generateJWTWebToken(User user)
        {
            var tokenHandler=new JwtSecurityTokenHandler();
            var key=Encoding.ASCII.GetBytes(_appSetting.Secret);

            var tokenDescriptor=new SecurityTokenDescriptor
            {
                Subject=new ClaimsIdentity(new[] {new Claim("id",user.Id.ToString())}),
                Expires=DateTime.UtcNow.AddDays(7),
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token=tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public List<User> GetAll()
        {
            return users;
        }

        public User GetById(int id)
        {
            User user=users.FirstOrDefault(x=>x.Id==id);
            return user;
        }
    }
}