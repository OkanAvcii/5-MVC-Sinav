using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.DTOs
{
    public class TopicGetDTO
    {
        public int Id { get; set; }
        [DisplayName("Topic")]
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
