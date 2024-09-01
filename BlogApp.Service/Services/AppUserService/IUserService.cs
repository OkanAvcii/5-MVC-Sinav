using BlogApp.Core.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Services.AppUserService
{
    public interface IUserService
    {
        AppUser GetUserById(string id);
        AppUser GetUserByEmail(string email);
        Task<IdentityResult> RegisterAsync(AppUser user, string password);
        Task<IdentityResult> UpdateUserAsync(AppUser user);
        Task<IdentityResult> DeleteUserAsync(string id);
    }
}
