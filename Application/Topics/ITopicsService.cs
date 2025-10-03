namespace Application.Topics
{
    public interface ITopicsService
    {
        Task<List<TopicResponseDto>> GetTopicsAsync();
        Task<TopicResponseDto> GetTopicAsync(Guid id);
        Task<TopicResponseDto> CreateTopicAsync(CreateTopicDto topicRequestDto);
        Task<TopicResponseDto> UpdateTopicAsync(Guid id, UpdateTopicDto topicRequestDto);
        Task DeleteTopicAsync(Guid id);

    }
}
