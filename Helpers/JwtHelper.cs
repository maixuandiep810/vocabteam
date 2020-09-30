// using System;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using Microsoft.IdentityModel.Tokens;
// using vocabteam.Models.Entities;

// namespace vocabteam.Helpers
// {
//     public class JwtMiddleware
//     { 
//         static string generateJwtToken(User user)
//         {
//             // generate token that is valid for 7 days
//             var tokenHandler = new JwtSecurityTokenHandler();
//             var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
//             var tokenDescriptor = new SecurityTokenDescriptor
//             {
//                 Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
//                 Expires = DateTime.UtcNow.AddDays(7),
//                 SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//             };
//             var token = tokenHandler.CreateToken(tokenDescriptor);
//             return tokenHandler.WriteToken(token);
//         }
//     }
// }