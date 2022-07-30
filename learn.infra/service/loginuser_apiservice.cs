using learn.core.Data;
using learn.core.Repository;
using learn.core.service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace learn.infra.service
{
    public class loginuser_apiservice : Iloginuser_apiservice
    {
        private readonly Iloginuser_apirepository authen;
        public loginuser_apiservice(Iloginuser_apirepository auth)
        {
            this.authen = auth;
        }
        public string Authentication_jwt(loginuser_api login)
        {
            var result = authen.auth(login);

            if (result == null)
            {
                return null;
            }
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]");
            var tokenDescirptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
             new Claim[]
                {
                    new Claim(ClaimTypes.Name,result.username),
                    
                    new Claim("userid", result.userid.ToString())

                }


                ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)


            };

            var generatetoken = tokenhandler.CreateToken(tokenDescirptor);
            
            return tokenhandler.WriteToken(generatetoken);
        }
     
    }
}
