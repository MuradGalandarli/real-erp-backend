using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;
using RealERP.Application.Exceptions;
using RealERP.Domain.Entities.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RealERP.Persistence.Service
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;

        public AuthService(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);

        }

        public async Task<TokenDto> LoginAsync(LoginDto login,int lifeTime,int refreshTokenLifeTime)
        {
            var user = await _userManager.FindByNameAsync(login.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
            {
                var token = await GetToken(user, lifeTime);
                //DateTime accessAndRefreshTokenEndTime = token.ValidTo.AddMinutes(refreshTokenLifeTime);
                DateTime refreshTokenEndDate = DateTime.UtcNow.AddMinutes(lifeTime + refreshTokenLifeTime);
                user.RefreshTokenEndDate = refreshTokenEndDate;
                user.RefreshToken = CreateRefreshToken();

                await _userManager.UpdateAsync(user);

            
                return new()
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo,
                    RefreshToken = user.RefreshToken
                };
            }
            return new();
        }

        public async Task<TokenDto> UpdateRefreshToken(string refreshToken, int accessTokenDate, int refreshTokenLifeTime)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if(user != null && DateTime.UtcNow < user.RefreshTokenEndDate)
            {
                var token = await GetToken(user, accessTokenDate);
                user.RefreshToken = CreateRefreshToken();
                DateTime refreshTokenEndDate = DateTime.UtcNow.AddMinutes(accessTokenDate + refreshTokenLifeTime);
                user.RefreshTokenEndDate = refreshTokenEndDate;
                IdentityResult result = await _userManager.UpdateAsync(user);
                return new()
                {
                    Expiration = token.ValidTo,
                    RefreshToken = user.RefreshToken,
                    Token = new JwtSecurityTokenHandler().WriteToken(token)


                };
            }
            throw new NotFoundException("There is not user");
        }

        private async Task<JwtSecurityToken> GetToken(AppUser user, int time)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddMinutes(time),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }

    }

}
