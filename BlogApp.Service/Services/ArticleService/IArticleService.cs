using BlogApp.Core.Concrete;
using BlogApp.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Services.ArticleService
{
    public interface IArticleService
    {
        int Create(ArticleCreateDTO model, string authorId);
        int Update(ArticleCreateDTO model, int id);
        int Delete(int id);
        ArticleGetDTO GetById(int id);
        IList<ArticleGetDTO> GetAll();
        List<Article> GetArticleByAuthorId(string authorId);

    }
}
