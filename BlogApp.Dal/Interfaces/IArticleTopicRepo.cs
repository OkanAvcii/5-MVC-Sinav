using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Dal.Interfaces
{
    public interface IArticleTopicRepo
    {
        int Create(int ArticleId, int TopicId);
        int Delete(int ArticleId, int TopicId);
        int Update(int ArticleId, int TopicId);
    }
}
