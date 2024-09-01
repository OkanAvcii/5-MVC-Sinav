using BlogApp.Core.Concrete;
using BlogApp.Dal.Concrete;
using BlogApp.Dal.Interfaces;
using BlogApp.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Services.TopicService
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepo _topicRepo;

        public TopicService(ITopicRepo topicRepo)
        {
            _topicRepo = topicRepo;
        }

        public int Create(TopicCreateDTO model)
        {
            try
            {
                var topic = new Topic { Name = model.Name, Description = model.Description };
                return _topicRepo.Create(topic);
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
                var topic = _topicRepo.GetById(id);
                if (topic != null)
                    return _topicRepo.Delete(topic);
                else
                    throw new Exception("Girilen Id doğru değil");
            }
            catch (Exception ex)
            {
                throw new Exception("Beklenmeyen bir hata gerçekleşti..." + ex.Message);
            }
        }

        public IList<TopicGetDTO> GetAll()
        {
            return _topicRepo.GetAll().Select(x => new TopicGetDTO { Id = x.Id, Name = x.Name, Description = x.Description }).ToList();
        }

        public TopicGetDTO GetById(int id)
        {
            if (_topicRepo.GetAny(x => x.Id == id))
            {
                var topic = _topicRepo.GetById(id);
                var topicDto = new TopicGetDTO { Id = topic.Id, Name = topic.Name, Description = topic.Description };
                return topicDto;
            }
            else
                throw new Exception("Böyle bir konu bulunamamaktadır.");
        }

        public int Update(TopicCreateDTO model, int id)
        {
            var topic = _topicRepo.GetById(id);
            if (topic is not null)
            {
                topic.Name = model.Name;
                topic.Description = model.Description;
                return _topicRepo.Update(topic);
            }
            else
            {
                throw new Exception("Beklenmeyen bir hata gerçekleşti");
            }
        }
    }
}
