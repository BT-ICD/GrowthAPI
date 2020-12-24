using Growth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Repository.Interfaces
{
    public interface ITopic
    {
        List<TopicDTOList> GetList(int chapterId);
        TopicDTOEdit GetById(int topicId);
        TopicDTOEdit Add(TopicDTOAdd topicDTOAdd);
        TopicDTOEdit Edit(TopicDTOEdit topicDTOEdit);
        DeleteResponse Delete(int topicId);
    }
}
