using BlogApp.Core.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Dal.Interfaces
{
    public interface IArticleRepo : IBaseRepo<Article>
    {
        IList<Article> GetArticlesByAuthor(string authorId);
    }
}
