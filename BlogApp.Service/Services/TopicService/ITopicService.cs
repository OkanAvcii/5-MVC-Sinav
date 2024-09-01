using BlogApp.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Services.TopicService
{
    public interface ITopicService
    {
        int Create(TopicCreateDTO model);
        int Update(TopicCreateDTO model, int id);
        int Delete(int id);
        TopicGetDTO GetById(int id);
        IList<TopicGetDTO> GetAll();
    }
}
