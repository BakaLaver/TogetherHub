using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Topics.Commands.Delete
{
    public record DeleteTopicCommand(Guid TopicID):ICommand<DeleteTopicResult>;

    public record DeleteTopicResult(bool IsSuccess);
}
