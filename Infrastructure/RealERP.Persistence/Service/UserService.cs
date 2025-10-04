using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;

namespace RealERP.Persistence.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
     
        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response> CreateAsync(RegisterDto register)
        {
            var userExists = await _userManager.FindByNameAsync(register.Username);
            if (userExists != null)
                return new Response { Status = "Error", Message = "User already exists!" };
            IdentityUser user = new()
            {
                Email = register.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = register.Username
            };
            var result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
                return new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." };
            return new Response { Status = "Success", Message = "User created successfully!" };
        }


    }
}
