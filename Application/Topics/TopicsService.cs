using Application.Data.DataBaseContext;
using Application.DTO;
using Application.Extensions;
using Domain.Model;
using Domain.ValueObjects;
using Microsoft.Extensions.Logging;
using System;

namespace Application.Topics
{
    public class TopicsService(IApplicationDbContext dbContext,
            ILogger<TopicsService> logger) : ITopicsService
    {

        public async Task<TopicResponseDto> CreateTopicAsync(CreateTopicDto dto)
        {
            Topic newTopic = Topic.Create(
                    TopicId.Of(Guid.NewGuid()),
                    dto.Title,
                    dto.EventStart,
                    dto.Summary,
                    dto.TopicType,
                    Location.Of(dto.Location.City, dto.Location.Street)
                );
            dbContext.Topics.Add(newTopic);
            await dbContext.SaveChangesAsync(CancellationToken.None);
            return newTopic.ToTopicResponseDto();
        }

        public async Task DeleteTopicAsync(Guid id)
        {
            TopicId topicId = TopicId.Of(id);
            var topic = await dbContext.Topics.FindAsync([topicId]);

            if (topic is null)
            {
                throw new TopicNotFoundException(id);
            }

            dbContext.Topics.Remove(topic);
            await dbContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<List<TopicResponseDto>> GetTopicsAsync()
        {
           
                var topics = await dbContext.Topics
                    .AsNoTracking()
                    .ToListAsync();
                return topics.ToTopicResponseDtoList();
            

        }

        public async Task<TopicResponseDto> GetTopicAsync(Guid id)
        {
            TopicId topicId = TopicId.Of(id);
            var result = await dbContext.Topics.FindAsync([topicId]);

            if(result is null) 
            {
                throw new TopicNotFoundException(id);
            }

            return result.ToTopicResponseDto();
        }

        public async Task<TopicResponseDto> UpdateTopicAsync(Guid id, UpdateTopicDto dto)
        {
            TopicId topicId = TopicId.Of(id);
            var topic = await dbContext.Topics.FindAsync([topicId]);

            if(topic is null) 
            {
                throw new TopicNotFoundException(id);
            }

            topic.Title = dto.Title ?? topic.Title;
            topic.Summary = dto.Summary ?? topic.Summary;
            topic.TopicType = dto.TopicType ?? topic.TopicType;
            topic.EventStrat = dto.EventStart;
            topic.Location = Location.Of(
                    dto.Location.City,
                    dto.Location.Street
                );

            await dbContext.SaveChangesAsync(CancellationToken.None);
            return topic.ToTopicResponseDto();
        }
    }
}
