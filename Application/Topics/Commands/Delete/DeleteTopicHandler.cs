using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Topics.Commands.Delete
{
    public class DeleteTopicHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteTopicCommand, DeleteTopicResult>
    {
        public async Task<DeleteTopicResult> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
        {
            TopicId topicId = TopicId.Of(request.TopicID);
            var topic = await dbContext.Topics.FindAsync([topicId], cancellationToken);

            if (topic is null || topic.IsDeleted)
            {
                throw new TopicNotFoundException(request.TopicID);
            }

            topic.IsDeleted = true;
            topic.DeletedAt = DateTimeOffset.UtcNow;
            await dbContext.SaveChangesAsync(CancellationToken.None);
            return new DeleteTopicResult(true);
        }
    }
}
