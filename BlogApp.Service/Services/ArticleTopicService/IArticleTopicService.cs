using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Services.ArticleTopicService
{
    public interface IArticleTopicService
    {
        int Create(int articleId, int topicId);
    }
}
