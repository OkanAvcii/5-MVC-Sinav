using BlogApp.Core.Concrete;
using BlogApp.Dal.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Services.AppUserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly UserManager<AppUser> _userManager;

        public UserService(IUserRepo userRepo, UserManager<AppUser> userManager)
        {
            _userRepo = userRepo;
            _userManager = userManager;
        }

        public async Task<IdentityResult> DeleteUserAsync(string id)
        {
            var user = _userRepo.GetById(id);
            if (user != null)
            {
                return await _userManager.DeleteAsync(user);
            }
            return IdentityResult.Failed(new IdentityError { Description = "User not found." });
        }

        public AppUser GetUserByEmail(string email)
        {
            return _userRepo.GetByEmail(email);
        }

        public AppUser GetUserById(string id)
        {
            return _userRepo.GetById(id);
        }

        public async Task<IdentityResult> RegisterAsync(AppUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> UpdateUserAsync(AppUser user)
        {
            return await _userManager.UpdateAsync(user);
        }
    }
}
