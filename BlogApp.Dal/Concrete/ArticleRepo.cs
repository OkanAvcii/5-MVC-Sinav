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
    public class ArticleRepo : BaseRepo<Article>, IArticleRepo
    {
        private readonly AppDbContext _context;
        public ArticleRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IList<Article> GetArticlesByAuthor(string authorId)
        {
            return _context.Articles.Where(x=>x.AuthorId == authorId).ToList();
        }
    }
}
