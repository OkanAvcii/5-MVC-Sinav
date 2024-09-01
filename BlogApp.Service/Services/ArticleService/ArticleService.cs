using BlogApp.Core.Concrete;
using BlogApp.Dal.Interfaces;
using BlogApp.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Services.ArticleService
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepo _articleRepo;

        public ArticleService(IArticleRepo articleRepo)
        {
            _articleRepo = articleRepo;
        }

        public int Create(ArticleCreateDTO model, string authorId)
        {
            try
            {
                var article = new Article { Title = model.Title, Content = model.Content, AuthorId = authorId, ImagePath = "Resim Yükle", ReadingTime = 5 };
                return _articleRepo.Create(article);
            }
            catch (Exception ex)
            {
                throw new Exception("Beklenmeyen bir hata gerçekleşti..." + ex.Message);
            }
        }

        public int Delete(int id)
        {
            try
            {
                var article = _articleRepo.GetById(id);
                if (article != null)
                    return _articleRepo.Delete(article);
                else
                    throw new Exception("Girilen Id doğru değil");
            }
            catch (Exception ex)
            {
                throw new Exception("Beklenmeyen bir hata gerçekleşti..." + ex.Message);
            }
        }

        public IList<ArticleGetDTO> GetAll()
        {
            return _articleRepo.GetAll().Select(x => new ArticleGetDTO { Id = x.Id, Title = x.Title, Content = x.Content, Author = x.Author }).ToList();
        }

        public List<Article> GetArticleByAuthorId(string authorId)
        {
            return _articleRepo.GetArticlesByAuthor(authorId).ToList();
        }

        public ArticleGetDTO GetById(int id)
        {
            if (_articleRepo.GetAny(x => x.Id == id))
            {
                var article = _articleRepo.GetById(id);
                var articleDto = new ArticleGetDTO { Id = article.Id, Title = article.Title, Content = article.Content };
                return articleDto;
            }
            else
                throw new Exception("Böyle bir makale bulunamamaktadır.");
        }

        public int Update(ArticleCreateDTO model, int id)
        {
            var article = _articleRepo.GetById(id);
            if (article is not null)
            {
                article.Title = model.Title;
                article.Content = model.Content;
                return _articleRepo.Update(article);
            }
            else
            {
                throw new Exception("Beklenmeyen bir hata gerçekleşti");
            }
        }
    }
}
