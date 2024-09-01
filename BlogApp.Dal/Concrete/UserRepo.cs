using BlogApp.Core.Concrete;
using BlogApp.Dal.Contexts;
using BlogApp.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Dal.Concrete
{
    public class UserRepo : BaseRepo<AppUser>, IUserRepo
    {
        private readonly AppDbContext _context;
        public UserRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public AppUser GetByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public AppUser GetById(string id)
        {
            return _context.Users.Find(id);
        }
    }
}
