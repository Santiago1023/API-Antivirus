using Api_Antivirus.Dto;

namespace Api_Antivirus.Mappers
{
    public class TopicMapper
    {
        public static Topic MapTopic(TopicDto topicDto)
        {
            return new Topic
            {
                Name = topicDto.Name
            };
        }

        public static TopicDto MapTopicDto(Topic topic)
        {
            return new TopicDto
            {
                Name = topic.Name
            };
        }
    }
}