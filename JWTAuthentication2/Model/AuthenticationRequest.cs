using System.ComponentModel.DataAnnotations;

namespace JWTAuthentication.Model
{
    public class AuthenticationRequest
    {
        [Required]
        public string UserName{get;set;}

        [Required]
        public string Password{get;set;}
    }

}