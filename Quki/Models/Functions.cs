using System.IdentityModel.Tokens.Jwt;

namespace Quki.Models
{
    public class Functions
    {
        public static JwtSecurityToken DecodeJwtToken(string id_token)
        {
            var jwt = id_token;
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadToken(jwt) as JwtSecurityToken;

            return token;
        }
    }
}
