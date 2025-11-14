using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.DTOs;
using RealERP.Application.Exceptions;
using RealERP.Application.Roles;
using RealERP.Domain.Entities.Identity;
using RealERP.Domain.Entities.User;

namespace RealERP.Persistence.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly ILogger<UserService> _logger;

        public UserService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, ILogger<UserService> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task<Response> CreateAsync(RegisterDto register,string role)
        {
            _logger.LogInformation("Test");
            {
                var userExists = await _userManager.FindByNameAsync(register.Username);
                if (userExists != null)
                    return new Response { Status = "Error", Message = "User already exists!" };
                AppUser user = new()
                {
                    Email = register.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = register.Username,
                    //DepartmentId = register.DepartmentId
                };
                var result = await _userManager.CreateAsync(user, register.Password);
                if (!result.Succeeded)
                    return new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." };
                if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                    await _roleManager.CreateAsync(new AppRole() {Name = UserRoles.Admin });
                if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                    await _roleManager.CreateAsync(new AppRole() {Name = UserRoles.User });
                if (role == "Admin")
                {
                    await _userManager.AddToRoleAsync(user, UserRoles.Admin);
                }
                if (role == "User")
                {
                    await _userManager.AddToRoleAsync(user, UserRoles.User);
                }
                return new Response { Status = "Success", Message = "User created successfully!" };
            }
        }
        public async Task<bool> DeleteUserByEmailAsync(string email)
        {
            AppUser? appUser = await _userManager.FindByEmailAsync(email);
            if (appUser == null)
                throw new NotFoundException($"User with email {email} not found");

           IdentityResult identityResult = await _userManager.DeleteAsync(appUser);
            return identityResult.Succeeded;

        }

        public async Task<List<UserDto>> GetAllUser(int Page, int Size)
        {
            var users = await _userManager.Users.Skip((Page-1)*Size).Take(Size).ToListAsync();
            return users.Select(u => new UserDto()
            {
                //DepartmentId = u.DepartmentId,
                Name = u.Name,
                Email = u.Email
            }).ToList();
        }

        public async Task<UserDto> GetByEmailUserAsync(string email)
        {
            AppUser? appUser = await _userManager.FindByEmailAsync(email);
            if(appUser == null)
                throw new NotFoundException($"User with email {email} not found");

            return new()
            {
               // DepartmentId = appUser.DepartmentId,
                Email = appUser.Email,
                Name = appUser.Name,
            };
        }

        public async Task<bool> UpdateUserAsync(RegisterDto register)
        {
            AppUser appUser = new()
            {
                Email = register.Email,
                UserName = register.Username

            };
            IdentityResult result = await _userManager.UpdateAsync(appUser);
            return result.Succeeded;
           
        }
    }
}

