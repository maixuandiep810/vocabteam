using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vocabteam.Helpers;
using vocabteam.Helpers.CustomExceptions;
using vocabteam.Models.Services;
using vocabteam.Models.ViewModels;

namespace vocabteam.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Token"].FirstOrDefault()?.Split(" ").Last();
            try
            {
                if (token != null)
                    attachUserToContext(context, userService, token);
                else
                    attachUserToGuestRole(context, userService);
                await _next(context);
            }
            catch (CustomException ex)
            {
                var failResponse = new BaseResponse((int)ex.Response_Code,
                                                    ConstantVar.ResponseString(ex.Response_Code));
                ResponseHelper.MiddlewareResponse(context, failResponse);
            }
            catch (Exception ex)
            {
                var failResponse = new BaseResponse((int)ConstantVar.ResponseCode.TOKEN_VALIDATION_ERROR,
                                                    ConstantVar.ResponseString(ConstantVar.ResponseCode.TOKEN_VALIDATION_ERROR));
                ResponseHelper.MiddlewareResponse(context, failResponse);
            }
        }

        private void attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var realToken = tokenHandler.ReadJwtToken(token);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // attach user to context on successful jwt validation
                var user = userService.GetById(userId);
                
                if (user.Token == null)
                {
                    throw new CustomException(ConstantVar.ResponseCode.HAVE_LOGGED_OUT);
                }

                context.Items["User"] = user;

            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void attachUserToGuestRole(HttpContext context, IUserService userService)
        {
            try
            {
                context.Items["User"] = userService.FindUserByUsername("guest");
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}