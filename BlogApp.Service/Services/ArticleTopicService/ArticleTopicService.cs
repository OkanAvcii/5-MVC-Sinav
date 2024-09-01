using BlogApp.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Services.ArticleTopicService
{
    public class ArticleTopicService : IArticleTopicService
    {
        private readonly IArticleTopicRepo _articleTopicRepo;

        public ArticleTopicService(IArticleTopicRepo articleTopicRepo)
        {
            _articleTopicRepo = articleTopicRepo;
        }

        public int Create(int articleId, int topicId)
        {
            return _articleTopicRepo.Create(articleId, topicId);
        }
    }
}
