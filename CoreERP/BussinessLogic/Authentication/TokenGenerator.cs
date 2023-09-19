using CoreERP.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.Authentication
{
    public enum CalimsKeys
    {
        UserId,
        UserName,
        BRANCHES
    }
    public class TokenGenerator
    {
        public static readonly  string Key= "COREERPSECURITYKEY";
        public static readonly string issUser= "COREERPSECURITYKEY";

        public string GenerateToken(Erpuser user)
        {
           
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
                var signCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                
                var claims = new[]
                {
                    new Claim(Convert.ToString(CalimsKeys.UserId),user.SeqId.ToString()),
                    new Claim(Convert.ToString(CalimsKeys.UserName),user.UserName),
                    //new Claim(Convert.ToString(CalimsKeys.BRANCHES),String.Join(",",branchCodes))
                };

                var token = new JwtSecurityToken(
                    issuer:issUser,
                    audience:issUser,
                    claims,
                    expires:DateTime.Now.AddHours(12),
                    signingCredentials: signCredentials
                    );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch(Exception ex)
            {
                throw new Exception("Failed to generate token"); ;
            }
        }
    }
}
