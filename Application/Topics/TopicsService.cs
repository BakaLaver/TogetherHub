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

        public Task<Topic> CreateTopicAsync(Topic topicRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTopicAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TopicResponseDto>> GetTopicsAsync()
        {
           
                var topics = await dbContext.Topics
                    .AsNoTracking()
                    .ToListAsync();
                return topics.ToTopicResponseDtoList();
            

        }

        public Task<TopicResponseDto> GetTopicAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Topic> UpdateTopicAsync(Guid id, Topic topicRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
