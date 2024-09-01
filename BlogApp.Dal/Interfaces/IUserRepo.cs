using BlogApp.Core.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Dal.Interfaces
{
    public interface IUserRepo : IBaseRepo<AppUser>
    {
        AppUser GetByEmail(string email);
        AppUser GetById(string id);
    }
}
