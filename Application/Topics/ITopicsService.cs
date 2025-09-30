using Domain.ValueObjects;

namespace Application.Topics
{
    public interface ITopicsService
    {
        Task<List<Topic>> GetTopicAsync();
        Task<Topic> GetTopicAsynck(Guid id);
        Task<Topic> CreateTopicAsync(Topic topicRequestDto);
        Task<Topic> UpdateTopicAsync(Guid id, Topic topicRequestDto);
        Task DeleteTopicAsync(Guid id);

    }
}
